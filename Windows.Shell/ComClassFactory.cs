using System;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using Vanara.Extensions;
using static Vanara.PInvoke.Ole32;

namespace Vanara.Windows.Shell
{
	/// <summary>An implementation of <see cref="IClassFactory"/> to be used with <see cref="ComObject"/> derivatives.</summary>
	/// <seealso cref="Vanara.PInvoke.Ole32.IClassFactory"/>
	/// <seealso cref="System.IDisposable"/>
	internal class ComClassFactory : IClassFactory, IDisposable
	{
		private readonly ComObject comObj;
		private uint registrationId;

		/// <summary>Initializes a new instance of the <see cref="ComClassFactory"/> class.</summary>
		/// <param name="punkObject">The COM object that is to be registered as a class object and queried for interfaces.</param>
		/// <param name="classContent">The context within which the COM object is to be run.</param>
		/// <param name="classUse">Indicates how connections are made to the class object.</param>
		public ComClassFactory(ComObject punkObject, CLSCTX classContent = CLSCTX.CLSCTX_LOCAL_SERVER, REGCLS classUse = REGCLS.REGCLS_SINGLEUSE)
		{
			comObj = punkObject ?? throw new ArgumentNullException(nameof(punkObject));
			CoRegisterClassObject(Marshal.GenerateGuidForType(comObj.GetType()), this, classContent, classUse, out registrationId);
		}

		/// <summary>Creates an uninitialized object.</summary>
		/// <param name="pUnkOuter">
		/// If the object is being created as part of an aggregate, specify a pointer to the controlling IUnknown interface of the
		/// aggregate. Otherwise, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="riid">
		/// A reference to the identifier of the interface to be used to communicate with the newly created object. If pUnkOuter is
		/// <c>NULL</c>, this parameter is generally the IID of the initializing interface; if pUnkOuter is non- <c>NULL</c>, riid must
		/// be IID_IUnknown.
		/// </param>
		/// <param name="ppvObject">
		/// The address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObject
		/// contains the requested interface pointer. If the object does not support the interface specified in riid, the implementation
		/// must set *ppvObject to <c>NULL</c>.
		/// </param>
		/// <param name="LockServer">The lock server.</param>
		/// <param name="">The .</param>
		/// <param name="fLock">The f lock.</param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The specified object was created.</term>
		/// </item>
		/// <item>
		/// <term>CLASS_E_NOAGGREGATION</term>
		/// <term>The pUnkOuter parameter was non-NULL and the object does not support aggregation.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The object that ppvObject points to does not support the interface identified by riid.</term>
		/// </item>
		/// </list>
		/// </returns>
		public virtual HRESULT CreateInstance(object punkOuter, in Guid riid, out object ppv)
		{
			ppv = null;
			if (!(punkOuter is null)) return HRESULT.CLASS_E_NOAGGREGATION;
			try
			{
				ppv = comObj.QueryInterface(riid);
			}
			catch (Exception e)
			{
				return e.GetPropertyValue<int>("HResult");
			}
			return HRESULT.S_OK;
		}

		/// <summary>Locks an object application open in memory. This enables instances to be created more quickly.</summary>
		/// <param name="fLock">If <c>TRUE</c>, increments the lock count; if <c>FALSE</c>, decrements the lock count.</param>
		/// <returns>This method can return the standard return values E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		/// <remarks>
		/// <c>IClassFactory::LockServer</c> controls whether an object's server is kept in memory. Keeping the application alive in
		/// memory allows instances to be created more quickly.
		/// </remarks>
		public virtual HRESULT LockServer(bool fLock)
		{
			if (fLock)
				CoAddRefServerProcess();
			else
			{
				if (0 == CoReleaseServerProcess())
					comObj?.QuitMessageLoop();
			}
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		public void Dispose()
		{
			if (registrationId == 0) return;
			CoRevokeClassObject(registrationId);
			registrationId = 0;
		}
	}
}