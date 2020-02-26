using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using Vanara.PInvoke;

namespace Vanara.Windows.Shell
{
    internal interface IMessageWindowHost
    {
        void WndProc(ref Message msg);
    }

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    [SecuritySafeCritical]
    internal class HostedMessageWindow<THost> : NativeWindow where THost : IMessageWindowHost
    {
        private readonly THost host;
        private GCHandle rooting;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        internal HostedMessageWindow(THost host) => this.host = host ?? throw new ArgumentNullException(nameof(host));

        ~HostedMessageWindow()
        {
            if (Handle != default && !DoNotClose)
                User32.PostMessage(Handle, (uint)User32.WindowMessage.WM_CLOSE);
        }

        protected virtual bool DoNotClose => false;

        public void LockReference(bool locked)
        {
            if (locked)
            {
                if (!rooting.IsAllocated)
                    rooting = GCHandle.Alloc(host, GCHandleType.Normal);
            }
            else
            {
                if (rooting.IsAllocated)
                    rooting.Free();
            }
        }

        protected override void OnThreadException(Exception e) => Application.OnThreadException(e);

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            host.WndProc(ref m);
            base.WndProc(ref m);
        }
    }

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class WindowMessageHook<THost> : HostedMessageWindow<THost> where THost : IMessageWindowHost
    {
        public WindowMessageHook(Control parent, THost host) : base(host)
        {
            if (parent is null) throw new ArgumentNullException(nameof(parent));
            parent.HandleCreated += (s, e) => AssignHandle(((Control)s).Handle);
            parent.HandleDestroyed += (s, e) => ReleaseHandle();
        }

        protected override bool DoNotClose => true;
    }
}