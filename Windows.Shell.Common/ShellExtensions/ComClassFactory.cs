using System;
using System.Runtime.InteropServices;
using Vanara.Extensions.Reflection;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;

namespace Vanara.Windows.Shell
{
	/// <summary>An implementation of <see cref="IClassFactory"/> to be used in conjunction with <see cref="IComObject"/> derivatives.</summary>
	/// <seealso cref="Vanara.PInvoke.Ole32.IClassFactory"/>
	/// <seealso cref="System.IDisposable"/>
	[ComVisible(true)]
	public class ComClassFactory : IClassFactory, IDisposable
	{
		private readonly IComObject comObj;
		private uint registrationId;

		/// <summary>Initializes a new instance of the <see cref="ComClassFactory"/> class.</summary>
		/// <param name="punkObject">The COM object that is to be registered as a class object and queried for interfaces.</param>
		/// <param name="classContext">The context within which the COM object is to be run.</param>
		/// <param name="classUse">Indicates how connections are made to the class object.</param>
		public ComClassFactory(IComObject punkObject, CLSCTX classContext, REGCLS classUse)
		{
			comObj = punkObject ?? throw new ArgumentNullException(nameof(punkObject));
			CoRegisterClassObject(comObj.GetType().CLSID(), this, classContext, classUse, out registrationId).ThrowIfFailed();
		}

		/// <summary>
		/// Resumes activation requests for class objects using <see cref="CoResumeClassObjects"/>. Must use
		/// <see cref="REGCLS.REGCLS_SUSPENDED"/> in the constructor.
		/// </summary>
		public void Resume() => CoResumeClassObjects().ThrowIfFailed();

		/// <summary>Creates an uninitialized object.</summary>
		/// <param name="pUnkOuter">
		/// If the object is being created as part of an aggregate, specify a pointer to the controlling IUnknown interface of the aggregate.
		/// Otherwise, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="riid">
		/// A reference to the identifier of the interface to be used to communicate with the newly created object. If pUnkOuter is
		/// <c>NULL</c>, this parameter is generally the IID of the initializing interface; if pUnkOuter is non- <c>NULL</c>, <paramref name="riid"/>
		/// must be IID_IUnknown.
		/// </param>
		/// <param name="ppv">
		/// The address of pointer variable that receives the interface pointer requested in <paramref name="riid"/>. Upon successful return, *ppvObject
		/// contains the requested interface pointer. If the object does not support the interface specified in <paramref name="riid"/>, the implementation must
		/// set *ppvObject to <c>NULL</c>.
		/// </param>
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
		/// <term>The object that ppvObject points to does not support the interface identified by <paramref name="riid"/>.</term>
		/// </item>
		/// </list>
		/// </returns>
		HRESULT IClassFactory.CreateInstance(object pUnkOuter, in Guid riid, out object ppv)
		{
			System.Diagnostics.Debug.WriteLine($"IClassFactory.CreateInstance: riid={riid:B}");
			ppv = null;
			if (!(pUnkOuter is null)) return HRESULT.CLASS_E_NOAGGREGATION;
			try
			{
				ppv = comObj.QueryInterface(riid);
				System.Diagnostics.Debug.WriteLine($"IClassFactory.CreateInstance: out ppv={ppv?.GetType().Name}");
			}
			catch (Exception e)
			{
				return e.GetPropertyValue<int>("HResult");
			}
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		void IDisposable.Dispose()
		{
			if (registrationId == 0) return;
			CoRevokeClassObject(registrationId);
			registrationId = 0;
		}

		/// <summary>Locks an object application open in memory. This enables instances to be created more quickly.</summary>
		/// <param name="fLock">If <c>TRUE</c>, increments the lock count; if <c>FALSE</c>, decrements the lock count.</param>
		/// <returns>This method can return the standard return values E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		/// <remarks>
		/// <c>IClassFactory::LockServer</c> controls whether an object's server is kept in memory. Keeping the application alive in memory
		/// allows instances to be created more quickly.
		/// </remarks>
		HRESULT IClassFactory.LockServer(bool fLock)
		{
			if (fLock)
			{
				CoAddRefServerProcess();
			}
			else
			{
				if (0 == CoReleaseServerProcess())
					comObj?.QuitMessageLoop();
			}
			return HRESULT.S_OK;
		}
	}
}