
.assembly extern mscorlib { }
//{
//  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
//  .ver 4:0:0:0
//}
.assembly extern stdole { }
//{
//  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
//  .ver 7:0:3300:0
//}
.assembly extern Vanara.PInvoke.Shared
{
  .ver 1:0:17:0
}
.assembly Vanara.PInvoke.NetListMgr
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 44 30 31 2D 35 37 30 46   // ..$DCB00D01-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .custom instance void [mscorlib]System.Runtime.InteropServices.ImportedFromTypeLibAttribute::.ctor(string) = ( 01 00 0B 4E 45 54 57 4F 52 4B 4C 49 53 54 00 00 ) // ...NETWORKLIST..
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibVersionAttribute::.ctor(int32,
                                                                                                int32) = ( 01 00 01 00 00 00 00 00 00 00 00 00 ) 
  .hash algorithm 0x00008004
  .ver 1:0:17:0
}
.module Vanara.PInvoke.NetListMgr.dll
// MVID: {E8D22024-F177-41E7-9951-FCE98090DA3B}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x03140000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed beforefieldinit Vanara.PInvoke.NetListMgr.NetworkPropertyName
  extends [mscorlib]System.Object
{
  .field public static literal string NA_DomainAuthenticationFailed = "NA_DomainAuthenticationFailed"
  .field public static literal string NA_NetworkClass = "NA_NetworkClass"
  .field public static literal string NA_NameSetByPolicy = "NA_NameSetByPolicy"
  .field public static literal string NA_IconSetByPolicy = "NA_IconSetByPolicy"
  .field public static literal string NA_DescriptionSetByPolicy = "NA_DescriptionSetByPolicy"
  .field public static literal string NA_CategorySetByPolicy = "NA_CategorySetByPolicy"
  .field public static literal string NA_NameReadOnly = "NA_NameReadOnly"
  .field public static literal string NA_IconReadOnly = "NA_IconReadOnly"
  .field public static literal string NA_DescriptionReadOnly = "NA_DescriptionReadOnly"
  .field public static literal string NA_CategoryReadOnly = "NA_CategoryReadOnly"
  .field public static literal string NA_AllowMerge = "NA_AllowMerge"
  .field public static literal string NA_InternetConnectivityV4 = "NA_InternetConnectivityV4"
  .field public static literal string NA_InternetConnectivityV6 = "NA_InternetConnectivityV6"
} // end of class Vanara.PInvoke.NetListMgr.NetworkPropertyName

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.INetworkListManager
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 40 10 00 00 00 00 )                         // ..@.....
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 30 2D 35 37 30 46   // ..$DCB00000-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .method public hidebysig newslot abstract virtual 
          instance class Vanara.PInvoke.NetListMgr.IEnumNetworks 
          marshal( interface ) 
          GetNetworks([in] valuetype Vanara.PInvoke.NetListMgr.NLM_ENUM_NETWORK Flags) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 01 00 00 00 00 00 ) 
  } // end of method INetworkListManager::GetNetworks

  .method public hidebysig newslot abstract virtual 
          instance class Vanara.PInvoke.NetListMgr.INetwork 
          marshal( interface ) 
          GetNetwork([in] valuetype [mscorlib]System.Guid gdNetworkId) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 02 00 00 00 00 00 ) 
  } // end of method INetworkListManager::GetNetwork

  .method public hidebysig newslot abstract virtual 
          instance class Vanara.PInvoke.NetListMgr.IEnumNetworkConnections 
          marshal( interface ) 
          GetNetworkConnections() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 03 00 00 00 00 00 ) 
  } // end of method INetworkListManager::GetNetworkConnections

  .method public hidebysig newslot abstract virtual 
          instance class Vanara.PInvoke.NetListMgr.INetworkConnection 
          marshal( interface ) 
          GetNetworkConnection([in] valuetype [mscorlib]System.Guid gdNetworkConnectionId) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 04 00 00 00 00 00 ) 
  } // end of method INetworkListManager::GetNetworkConnection

  .method public hidebysig newslot specialname abstract virtual 
          instance bool  get_IsConnectedToInternet() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 05 00 00 00 00 00 ) 
  } // end of method INetworkListManager::get_IsConnectedToInternet

  .method public hidebysig newslot specialname abstract virtual 
          instance bool  get_IsConnected() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 06 00 00 00 00 00 ) 
  } // end of method INetworkListManager::get_IsConnected

  .method public hidebysig newslot abstract virtual 
          instance valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY 
          GetConnectivity() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 07 00 00 00 00 00 ) 
  } // end of method INetworkListManager::GetConnectivity

  .method public hidebysig newslot abstract virtual 
          instance void  SetSimulatedProfileInfo([in] valuetype Vanara.PInvoke.NetListMgr.NLM_SIMULATED_PROFILE_INFO& pSimulatedInfo) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  } // end of method INetworkListManager::SetSimulatedProfileInfo

  .method public hidebysig newslot abstract virtual 
          instance void  ClearSimulatedProfileInfo() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 09 00 00 00 00 00 ) 
  } // end of method INetworkListManager::ClearSimulatedProfileInfo

  .property bool IsConnectedToInternet()
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 05 00 00 00 00 00 ) 
    .get instance bool Vanara.PInvoke.NetListMgr.INetworkListManager::get_IsConnectedToInternet()
  } // end of property INetworkListManager::IsConnectedToInternet
  .property bool IsConnected()
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 06 00 00 00 00 00 ) 
    .get instance bool Vanara.PInvoke.NetListMgr.INetworkListManager::get_IsConnected()
  } // end of property INetworkListManager::IsConnected
} // end of class Vanara.PInvoke.NetListMgr.INetworkListManager

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.INetworkEvents
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 34 2D 35 37 30 46   // ..$DCB00004-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 00 01 00 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  NetworkAdded([in] valuetype [mscorlib]System.Guid networkId) runtime managed internalcall
  {
  } // end of method INetworkEvents::NetworkAdded

  .method public hidebysig newslot abstract virtual 
          instance void  NetworkDeleted([in] valuetype [mscorlib]System.Guid networkId) runtime managed internalcall
  {
  } // end of method INetworkEvents::NetworkDeleted

  .method public hidebysig newslot abstract virtual 
          instance void  NetworkConnectivityChanged([in] valuetype [mscorlib]System.Guid networkId,
                                                    [in] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY newConnectivity) runtime managed internalcall
  {
  } // end of method INetworkEvents::NetworkConnectivityChanged

  .method public hidebysig newslot abstract virtual 
          instance void  NetworkPropertyChanged([in] valuetype [mscorlib]System.Guid networkId,
                                                [in] valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_PROPERTY_CHANGE Flags) runtime managed internalcall
  {
  } // end of method INetworkEvents::NetworkPropertyChanged

} // end of class Vanara.PInvoke.NetListMgr.INetworkEvents

.class interface public abstract auto ansi Vanara.PInvoke.NetListMgr.INetworkEvents_Event
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComEventInterfaceAttribute::.ctor(class [mscorlib]System.Type,
                                                                                                   class [mscorlib]System.Type) = ( 01 00 28 56 61 6E 61 72 61 2E 50 49 6E 76 6F 6B   // ..(Vanara.PInvok
                                                                                                                                    65 2E 4E 65 74 4C 69 73 74 4D 67 72 2E 49 4E 65   // e.NetListMgr.INe
                                                                                                                                    74 77 6F 72 6B 45 76 65 6E 74 73 36 56 61 6E 61   // tworkEvents6Vana
                                                                                                                                    72 61 2E 50 49 6E 76 6F 6B 65 2E 4E 65 74 4C 69   // ra.PInvoke.NetLi
                                                                                                                                    73 74 4D 67 72 2E 49 4E 65 74 77 6F 72 6B 45 76   // stMgr.INetworkEv
                                                                                                                                    65 6E 74 73 5F 45 76 65 6E 74 50 72 6F 76 69 64   // ents_EventProvid
                                                                                                                                    65 72 00 00 )                                     // er..
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  add_NetworkAdded(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkEvents_Event::add_NetworkAdded

  .method public hidebysig newslot abstract virtual 
          instance void  remove_NetworkAdded(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkEvents_Event::remove_NetworkAdded

  .method public hidebysig newslot abstract virtual 
          instance void  add_NetworkDeleted(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkEvents_Event::add_NetworkDeleted

  .method public hidebysig newslot abstract virtual 
          instance void  remove_NetworkDeleted(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkEvents_Event::remove_NetworkDeleted

  .method public hidebysig newslot abstract virtual 
          instance void  add_NetworkConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkEvents_Event::add_NetworkConnectivityChanged

  .method public hidebysig newslot abstract virtual 
          instance void  remove_NetworkConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkEvents_Event::remove_NetworkConnectivityChanged

  .method public hidebysig newslot abstract virtual 
          instance void  add_NetworkPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkEvents_Event::add_NetworkPropertyChanged

  .method public hidebysig newslot abstract virtual 
          instance void  remove_NetworkPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkEvents_Event::remove_NetworkPropertyChanged

  .event Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler NetworkAdded
  {
    .addon instance void Vanara.PInvoke.NetListMgr.INetworkEvents_Event::add_NetworkAdded(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.INetworkEvents_Event::remove_NetworkAdded(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler)
  } // end of event INetworkEvents_Event::NetworkAdded
  .event Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler NetworkDeleted
  {
    .addon instance void Vanara.PInvoke.NetListMgr.INetworkEvents_Event::add_NetworkDeleted(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.INetworkEvents_Event::remove_NetworkDeleted(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler)
  } // end of event INetworkEvents_Event::NetworkDeleted
  .event Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler NetworkConnectivityChanged
  {
    .addon instance void Vanara.PInvoke.NetListMgr.INetworkEvents_Event::add_NetworkConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.INetworkEvents_Event::remove_NetworkConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler)
  } // end of event INetworkEvents_Event::NetworkConnectivityChanged
  .event Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler NetworkPropertyChanged
  {
    .addon instance void Vanara.PInvoke.NetListMgr.INetworkEvents_Event::add_NetworkPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.INetworkEvents_Event::remove_NetworkPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler)
  } // end of event INetworkEvents_Event::NetworkPropertyChanged
} // end of class Vanara.PInvoke.NetListMgr.INetworkEvents_Event

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.NetworkListManager
       implements Vanara.PInvoke.NetListMgr.INetworkListManager,
                  Vanara.PInvoke.NetListMgr.INetworkEvents_Event
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.CoClassAttribute::.ctor(class [mscorlib]System.Type) = ( 01 00 31 56 61 6E 61 72 61 2E 50 49 6E 76 6F 6B   // ..1Vanara.PInvok
                                                                                                                          65 2E 4E 65 74 4C 69 73 74 4D 67 72 2E 4E 65 74   // e.NetListMgr.Net
                                                                                                                          77 6F 72 6B 4C 69 73 74 4D 61 6E 61 67 65 72 43   // workListManagerC
                                                                                                                          6C 61 73 73 00 00 )                               // lass..
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 30 2D 35 37 30 46   // ..$DCB00000-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
} // end of class Vanara.PInvoke.NetListMgr.NetworkListManager

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.INetworkCostManager
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 38 2D 35 37 30 46   // ..$DCB00008-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .method public hidebysig newslot abstract virtual 
          instance void  GetCost([out] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST& pCost,
                                 [in]  native int pDestIPAddr) runtime managed internalcall
  {
  } // end of method INetworkCostManager::GetCost

  .method public hidebysig newslot abstract virtual 
          instance void  GetDataPlanStatus([out] valuetype Vanara.PInvoke.NetListMgr.NLM_DATAPLAN_STATUS& pDataPlanStatus,
                                           [in]  native int pDestIPAddr) runtime managed internalcall
  {
  } // end of method INetworkCostManager::GetDataPlanStatus

  .method public hidebysig newslot abstract virtual 
          instance void  SetDestinationAddresses([in] uint32 length,
                                                 [in] native int pDestIPAddrList,
                                                 [in] bool bAppend) runtime managed internalcall
  {
  } // end of method INetworkCostManager::SetDestinationAddresses

} // end of class Vanara.PInvoke.NetListMgr.INetworkCostManager

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.INetworkConnectionEvents
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 37 2D 35 37 30 46   // ..$DCB00007-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 00 01 00 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  NetworkConnectionConnectivityChanged([in] valuetype [mscorlib]System.Guid connectionId,
                                                              [in] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY newConnectivity) runtime managed internalcall
  {
  } // end of method INetworkConnectionEvents::NetworkConnectionConnectivityChanged

  .method public hidebysig newslot abstract virtual 
          instance void  NetworkConnectionPropertyChanged([in] valuetype [mscorlib]System.Guid connectionId,
                                                          [in] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_PROPERTY_CHANGE Flags) runtime managed internalcall
  {
  } // end of method INetworkConnectionEvents::NetworkConnectionPropertyChanged

} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents

.class interface public abstract auto ansi Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_Event
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComEventInterfaceAttribute::.ctor(class [mscorlib]System.Type,
                                                                                                   class [mscorlib]System.Type) = ( 01 00 32 56 61 6E 61 72 61 2E 50 49 6E 76 6F 6B   // ..2Vanara.PInvok
                                                                                                                                    65 2E 4E 65 74 4C 69 73 74 4D 67 72 2E 49 4E 65   // e.NetListMgr.INe
                                                                                                                                    74 77 6F 72 6B 43 6F 6E 6E 65 63 74 69 6F 6E 45   // tworkConnectionE
                                                                                                                                    76 65 6E 74 73 40 56 61 6E 61 72 61 2E 50 49 6E   // vents@Vanara.PIn
                                                                                                                                    76 6F 6B 65 2E 4E 65 74 4C 69 73 74 4D 67 72 2E   // voke.NetListMgr.
                                                                                                                                    49 4E 65 74 77 6F 72 6B 43 6F 6E 6E 65 63 74 69   // INetworkConnecti
                                                                                                                                    6F 6E 45 76 65 6E 74 73 5F 45 76 65 6E 74 50 72   // onEvents_EventPr
                                                                                                                                    6F 76 69 64 65 72 00 00 )                         // ovider..
  .method public hidebysig newslot abstract virtual 
          instance void  add_NetworkConnectionConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkConnectionEvents_Event::add_NetworkConnectionConnectivityChanged

  .method public hidebysig newslot abstract virtual 
          instance void  remove_NetworkConnectionConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkConnectionEvents_Event::remove_NetworkConnectionConnectivityChanged

  .method public hidebysig newslot abstract virtual 
          instance void  add_NetworkConnectionPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkConnectionEvents_Event::add_NetworkConnectionPropertyChanged

  .method public hidebysig newslot abstract virtual 
          instance void  remove_NetworkConnectionPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkConnectionEvents_Event::remove_NetworkConnectionPropertyChanged

  .event Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler NetworkConnectionConnectivityChanged
  {
    .addon instance void Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_Event::add_NetworkConnectionConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_Event::remove_NetworkConnectionConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler)
  } // end of event INetworkConnectionEvents_Event::NetworkConnectionConnectivityChanged
  .event Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler NetworkConnectionPropertyChanged
  {
    .removeon instance void Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_Event::remove_NetworkConnectionPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler)
    .addon instance void Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_Event::add_NetworkConnectionPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler)
  } // end of event INetworkConnectionEvents_Event::NetworkConnectionPropertyChanged
} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_Event

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.INetworkListManagerEvents
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 00 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 31 2D 35 37 30 46   // ..$DCB00001-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .method public hidebysig newslot abstract virtual 
          instance void  ConnectivityChanged([in] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY newConnectivity) runtime managed internalcall
  {
  } // end of method INetworkListManagerEvents::ConnectivityChanged

} // end of class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents

.class interface public abstract auto ansi Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_Event
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComEventInterfaceAttribute::.ctor(class [mscorlib]System.Type,
                                                                                                   class [mscorlib]System.Type) = ( 01 00 33 56 61 6E 61 72 61 2E 50 49 6E 76 6F 6B   // ..3Vanara.PInvok
                                                                                                                                    65 2E 4E 65 74 4C 69 73 74 4D 67 72 2E 49 4E 65   // e.NetListMgr.INe
                                                                                                                                    74 77 6F 72 6B 4C 69 73 74 4D 61 6E 61 67 65 72   // tworkListManager
                                                                                                                                    45 76 65 6E 74 73 41 56 61 6E 61 72 61 2E 50 49   // EventsAVanara.PI
                                                                                                                                    6E 76 6F 6B 65 2E 4E 65 74 4C 69 73 74 4D 67 72   // nvoke.NetListMgr
                                                                                                                                    2E 49 4E 65 74 77 6F 72 6B 4C 69 73 74 4D 61 6E   // .INetworkListMan
                                                                                                                                    61 67 65 72 45 76 65 6E 74 73 5F 45 76 65 6E 74   // agerEvents_Event
                                                                                                                                    50 72 6F 76 69 64 65 72 00 00 )                   // Provider..
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  add_ConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkListManagerEvents_Event::add_ConnectivityChanged

  .method public hidebysig newslot abstract virtual 
          instance void  remove_ConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkListManagerEvents_Event::remove_ConnectivityChanged

  .event Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler ConnectivityChanged
  {
    .addon instance void Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_Event::add_ConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_Event::remove_ConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler)
  } // end of event INetworkListManagerEvents_Event::ConnectivityChanged
} // end of class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_Event

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 39 2D 35 37 30 46   // ..$DCB00009-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .method public hidebysig newslot abstract virtual 
          instance void  CostChanged([in] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST newCost,
                                     [in] valuetype Vanara.PInvoke.NetListMgr.NLM_SOCKADDR& pDestAddr) runtime managed internalcall
  {
  } // end of method INetworkCostManagerEvents::CostChanged

  .method public hidebysig newslot abstract virtual 
          instance void  DataPlanStatusChanged([in] valuetype Vanara.PInvoke.NetListMgr.NLM_SOCKADDR& pDestAddr) runtime managed internalcall
  {
  } // end of method INetworkCostManagerEvents::DataPlanStatusChanged

} // end of class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents

.class interface public abstract auto ansi Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_Event
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComEventInterfaceAttribute::.ctor(class [mscorlib]System.Type,
                                                                                                   class [mscorlib]System.Type) = ( 01 00 33 56 61 6E 61 72 61 2E 50 49 6E 76 6F 6B   // ..3Vanara.PInvok
                                                                                                                                    65 2E 4E 65 74 4C 69 73 74 4D 67 72 2E 49 4E 65   // e.NetListMgr.INe
                                                                                                                                    74 77 6F 72 6B 43 6F 73 74 4D 61 6E 61 67 65 72   // tworkCostManager
                                                                                                                                    45 76 65 6E 74 73 41 56 61 6E 61 72 61 2E 50 49   // EventsAVanara.PI
                                                                                                                                    6E 76 6F 6B 65 2E 4E 65 74 4C 69 73 74 4D 67 72   // nvoke.NetListMgr
                                                                                                                                    2E 49 4E 65 74 77 6F 72 6B 43 6F 73 74 4D 61 6E   // .INetworkCostMan
                                                                                                                                    61 67 65 72 45 76 65 6E 74 73 5F 45 76 65 6E 74   // agerEvents_Event
                                                                                                                                    50 72 6F 76 69 64 65 72 00 00 )                   // Provider..
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  add_CostChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkCostManagerEvents_Event::add_CostChanged

  .method public hidebysig newslot abstract virtual 
          instance void  remove_CostChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkCostManagerEvents_Event::remove_CostChanged

  .method public hidebysig newslot abstract virtual 
          instance void  add_DataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkCostManagerEvents_Event::add_DataPlanStatusChanged

  .method public hidebysig newslot abstract virtual 
          instance void  remove_DataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkCostManagerEvents_Event::remove_DataPlanStatusChanged

  .event Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler CostChanged
  {
    .addon instance void Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_Event::add_CostChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_Event::remove_CostChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler)
  } // end of event INetworkCostManagerEvents_Event::CostChanged
  .event Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler DataPlanStatusChanged
  {
    .addon instance void Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_Event::add_DataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_Event::remove_DataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler)
  } // end of event INetworkCostManagerEvents_Event::DataPlanStatusChanged
} // end of class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_Event

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 42 2D 35 37 30 46   // ..$DCB0000B-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  ConnectionCostChanged([in] valuetype [mscorlib]System.Guid connectionId,
                                               [in] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST newCost) runtime managed internalcall
  {
  } // end of method INetworkConnectionCostEvents::ConnectionCostChanged

  .method public hidebysig newslot abstract virtual 
          instance void  ConnectionDataPlanStatusChanged([in] valuetype [mscorlib]System.Guid connectionId) runtime managed internalcall
  {
  } // end of method INetworkConnectionCostEvents::ConnectionDataPlanStatusChanged

} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents

.class interface public abstract auto ansi Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_Event
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComEventInterfaceAttribute::.ctor(class [mscorlib]System.Type,
                                                                                                   class [mscorlib]System.Type) = ( 01 00 36 56 61 6E 61 72 61 2E 50 49 6E 76 6F 6B   // ..6Vanara.PInvok
                                                                                                                                    65 2E 4E 65 74 4C 69 73 74 4D 67 72 2E 49 4E 65   // e.NetListMgr.INe
                                                                                                                                    74 77 6F 72 6B 43 6F 6E 6E 65 63 74 69 6F 6E 43   // tworkConnectionC
                                                                                                                                    6F 73 74 45 76 65 6E 74 73 44 56 61 6E 61 72 61   // ostEventsDVanara
                                                                                                                                    2E 50 49 6E 76 6F 6B 65 2E 4E 65 74 4C 69 73 74   // .PInvoke.NetList
                                                                                                                                    4D 67 72 2E 49 4E 65 74 77 6F 72 6B 43 6F 6E 6E   // Mgr.INetworkConn
                                                                                                                                    65 63 74 69 6F 6E 43 6F 73 74 45 76 65 6E 74 73   // ectionCostEvents
                                                                                                                                    5F 45 76 65 6E 74 50 72 6F 76 69 64 65 72 00 00 ) // _EventProvider..
  .method public hidebysig newslot abstract virtual 
          instance void  add_ConnectionCostChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkConnectionCostEvents_Event::add_ConnectionCostChanged

  .method public hidebysig newslot abstract virtual 
          instance void  remove_ConnectionCostChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkConnectionCostEvents_Event::remove_ConnectionCostChanged

  .method public hidebysig newslot abstract virtual 
          instance void  add_ConnectionDataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkConnectionCostEvents_Event::add_ConnectionDataPlanStatusChanged

  .method public hidebysig newslot abstract virtual 
          instance void  remove_ConnectionDataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler A_1) runtime managed internalcall
  {
  } // end of method INetworkConnectionCostEvents_Event::remove_ConnectionDataPlanStatusChanged

  .event Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler ConnectionCostChanged
  {
    .removeon instance void Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_Event::remove_ConnectionCostChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler)
    .addon instance void Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_Event::add_ConnectionCostChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler)
  } // end of event INetworkConnectionCostEvents_Event::ConnectionCostChanged
  .event Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler ConnectionDataPlanStatusChanged
  {
    .addon instance void Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_Event::add_ConnectionDataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_Event::remove_ConnectionDataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler)
  } // end of event INetworkConnectionCostEvents_Event::ConnectionDataPlanStatusChanged
} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_Event

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.IPropertyBag
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 35 35 32 37 32 41 30 30 2D 34 32 43 42   // ..$55272A00-42CB
                                                                                                  2D 31 31 43 45 2D 38 31 33 35 2D 30 30 41 41 30   // -11CE-8135-00AA0
                                                                                                  30 34 42 42 38 35 31 00 00 )                      // 04BB851..
  .method public hidebysig newslot abstract virtual 
          instance void  RemoteRead([in] string  marshal( lpwstr) pszPropName,
                                    [out] object&  marshal( struct) pVar,
                                    [in] class Vanara.PInvoke.NetListMgr.IErrorLog  marshal( interface ) pErrorLog,
                                    [in] uint32 varType,
                                    [in] object  marshal( iunknown ) pUnkObj) runtime managed internalcall
  {
  } // end of method IPropertyBag::RemoteRead

  .method public hidebysig newslot abstract virtual 
          instance void  Write([in] string  marshal( lpwstr) pszPropName,
                               [in] object&  marshal( struct) pVar) runtime managed internalcall
  {
  } // end of method IPropertyBag::Write

} // end of class Vanara.PInvoke.NetListMgr.IPropertyBag

.class public auto ansi import Vanara.PInvoke.NetListMgr.NetworkListManagerClass
       extends [mscorlib]System.Object
       implements Vanara.PInvoke.NetListMgr.INetworkListManager,
                  Vanara.PInvoke.NetListMgr.NetworkListManager,
                  Vanara.PInvoke.NetListMgr.INetworkEvents_Event,
                  Vanara.PInvoke.NetListMgr.INetworkCostManager,
                  Vanara.PInvoke.NetListMgr.IPropertyBag,
                  Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_Event,
                  Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_Event,
                  Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_Event,
                  Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_Event
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 02 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ClassInterfaceType) = ( 01 00 00 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 43 30 31 2D 35 37 30 46   // ..$DCB00C01-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComSourceInterfacesAttribute::.ctor(string) = ( 01 00 80 FC 56 61 6E 61 72 61 2E 50 49 6E 76 6F   // ....Vanara.PInvo
                                                                                                                 6B 65 2E 4E 65 74 4C 69 73 74 4D 67 72 2E 49 4E   // ke.NetListMgr.IN
                                                                                                                 65 74 77 6F 72 6B 45 76 65 6E 74 73 00 56 61 6E   // etworkEvents.Van
                                                                                                                 61 72 61 2E 50 49 6E 76 6F 6B 65 2E 4E 65 74 4C   // ara.PInvoke.NetL
                                                                                                                 69 73 74 4D 67 72 2E 49 4E 65 74 77 6F 72 6B 43   // istMgr.INetworkC
                                                                                                                 6F 6E 6E 65 63 74 69 6F 6E 45 76 65 6E 74 73 00   // onnectionEvents.
                                                                                                                 56 61 6E 61 72 61 2E 50 49 6E 76 6F 6B 65 2E 4E   // Vanara.PInvoke.N
                                                                                                                 65 74 4C 69 73 74 4D 67 72 2E 49 4E 65 74 77 6F   // etListMgr.INetwo
                                                                                                                 72 6B 4C 69 73 74 4D 61 6E 61 67 65 72 45 76 65   // rkListManagerEve
                                                                                                                 6E 74 73 00 56 61 6E 61 72 61 2E 50 49 6E 76 6F   // nts.Vanara.PInvo
                                                                                                                 6B 65 2E 4E 65 74 4C 69 73 74 4D 67 72 2E 49 4E   // ke.NetListMgr.IN
                                                                                                                 65 74 77 6F 72 6B 43 6F 73 74 4D 61 6E 61 67 65   // etworkCostManage
                                                                                                                 72 45 76 65 6E 74 73 00 56 61 6E 61 72 61 2E 50   // rEvents.Vanara.P
                                                                                                                 49 6E 76 6F 6B 65 2E 4E 65 74 4C 69 73 74 4D 67   // Invoke.NetListMg
                                                                                                                 72 2E 49 4E 65 74 77 6F 72 6B 43 6F 6E 6E 65 63   // r.INetworkConnec
                                                                                                                 74 69 6F 6E 43 6F 73 74 45 76 65 6E 74 73 00 00   // tionCostEvents..
                                                                                                                 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor() runtime managed internalcall
  {
  } // end of method NetworkListManagerClass::.ctor

  .method public hidebysig newslot virtual 
          instance class Vanara.PInvoke.NetListMgr.IEnumNetworks 
          marshal( interface ) 
          GetNetworks([in] valuetype Vanara.PInvoke.NetListMgr.NLM_ENUM_NETWORK Flags) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 01 00 00 00 00 00 ) 
    .override Vanara.PInvoke.NetListMgr.INetworkListManager::GetNetworks
  } // end of method NetworkListManagerClass::GetNetworks

  .method public hidebysig newslot virtual 
          instance class Vanara.PInvoke.NetListMgr.INetwork 
          marshal( interface ) 
          GetNetwork([in] valuetype [mscorlib]System.Guid gdNetworkId) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 02 00 00 00 00 00 ) 
    .override Vanara.PInvoke.NetListMgr.INetworkListManager::GetNetwork
  } // end of method NetworkListManagerClass::GetNetwork

  .method public hidebysig newslot virtual 
          instance class Vanara.PInvoke.NetListMgr.IEnumNetworkConnections 
          marshal( interface ) 
          GetNetworkConnections() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 03 00 00 00 00 00 ) 
    .override Vanara.PInvoke.NetListMgr.INetworkListManager::GetNetworkConnections
  } // end of method NetworkListManagerClass::GetNetworkConnections

  .method public hidebysig newslot virtual 
          instance class Vanara.PInvoke.NetListMgr.INetworkConnection 
          marshal( interface ) 
          GetNetworkConnection([in] valuetype [mscorlib]System.Guid gdNetworkConnectionId) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 04 00 00 00 00 00 ) 
    .override Vanara.PInvoke.NetListMgr.INetworkListManager::GetNetworkConnection
  } // end of method NetworkListManagerClass::GetNetworkConnection

  .method public hidebysig newslot specialname virtual 
          instance bool  get_IsConnectedToInternet() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 05 00 00 00 00 00 ) 
    .override Vanara.PInvoke.NetListMgr.INetworkListManager::get_IsConnectedToInternet
  } // end of method NetworkListManagerClass::get_IsConnectedToInternet

  .method public hidebysig newslot specialname virtual 
          instance bool  get_IsConnected() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 06 00 00 00 00 00 ) 
    .override Vanara.PInvoke.NetListMgr.INetworkListManager::get_IsConnected
  } // end of method NetworkListManagerClass::get_IsConnected

  .method public hidebysig newslot virtual 
          instance valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY 
          GetConnectivity() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 07 00 00 00 00 00 ) 
    .override Vanara.PInvoke.NetListMgr.INetworkListManager::GetConnectivity
  } // end of method NetworkListManagerClass::GetConnectivity

  .method public hidebysig newslot virtual 
          instance void  SetSimulatedProfileInfo([in] valuetype Vanara.PInvoke.NetListMgr.NLM_SIMULATED_PROFILE_INFO& pSimulatedInfo) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
    .override Vanara.PInvoke.NetListMgr.INetworkListManager::SetSimulatedProfileInfo
  } // end of method NetworkListManagerClass::SetSimulatedProfileInfo

  .method public hidebysig newslot virtual 
          instance void  ClearSimulatedProfileInfo() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 09 00 00 00 00 00 ) 
    .override Vanara.PInvoke.NetListMgr.INetworkListManager::ClearSimulatedProfileInfo
  } // end of method NetworkListManagerClass::ClearSimulatedProfileInfo

  .method public hidebysig newslot virtual 
          instance void  add_NetworkAdded(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkEvents_Event::add_NetworkAdded
  } // end of method NetworkListManagerClass::add_NetworkAdded

  .method public hidebysig newslot virtual 
          instance void  remove_NetworkAdded(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkEvents_Event::remove_NetworkAdded
  } // end of method NetworkListManagerClass::remove_NetworkAdded

  .method public hidebysig newslot virtual 
          instance void  add_NetworkDeleted(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkEvents_Event::add_NetworkDeleted
  } // end of method NetworkListManagerClass::add_NetworkDeleted

  .method public hidebysig newslot virtual 
          instance void  remove_NetworkDeleted(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkEvents_Event::remove_NetworkDeleted
  } // end of method NetworkListManagerClass::remove_NetworkDeleted

  .method public hidebysig newslot virtual 
          instance void  add_NetworkConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkEvents_Event::add_NetworkConnectivityChanged
  } // end of method NetworkListManagerClass::add_NetworkConnectivityChanged

  .method public hidebysig newslot virtual 
          instance void  remove_NetworkConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkEvents_Event::remove_NetworkConnectivityChanged
  } // end of method NetworkListManagerClass::remove_NetworkConnectivityChanged

  .method public hidebysig newslot virtual 
          instance void  add_NetworkPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkEvents_Event::add_NetworkPropertyChanged
  } // end of method NetworkListManagerClass::add_NetworkPropertyChanged

  .method public hidebysig newslot virtual 
          instance void  remove_NetworkPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkEvents_Event::remove_NetworkPropertyChanged
  } // end of method NetworkListManagerClass::remove_NetworkPropertyChanged

  .method public hidebysig newslot virtual 
          instance void  GetCost([out] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST& pCost,
                                 [in]  native int pDestIPAddr) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkCostManager::GetCost
  } // end of method NetworkListManagerClass::GetCost

  .method public hidebysig newslot virtual 
          instance void  GetDataPlanStatus([out] valuetype Vanara.PInvoke.NetListMgr.NLM_DATAPLAN_STATUS& pDataPlanStatus,
                                           [in]  native int pDestIPAddr) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkCostManager::GetDataPlanStatus
  } // end of method NetworkListManagerClass::GetDataPlanStatus

  .method public hidebysig newslot virtual 
          instance void  SetDestinationAddresses([in] uint32 length,
                                                 [in] native int pDestIPAddrList,
                                                 [in] bool bAppend) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkCostManager::SetDestinationAddresses
  } // end of method NetworkListManagerClass::SetDestinationAddresses

  .method public hidebysig newslot virtual 
          instance void  add_NetworkConnectionConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_Event::add_NetworkConnectionConnectivityChanged
  } // end of method NetworkListManagerClass::add_NetworkConnectionConnectivityChanged

  .method public hidebysig newslot virtual 
          instance void  remove_NetworkConnectionConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_Event::remove_NetworkConnectionConnectivityChanged
  } // end of method NetworkListManagerClass::remove_NetworkConnectionConnectivityChanged

  .method public hidebysig newslot virtual 
          instance void  add_NetworkConnectionPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_Event::add_NetworkConnectionPropertyChanged
  } // end of method NetworkListManagerClass::add_NetworkConnectionPropertyChanged

  .method public hidebysig newslot virtual 
          instance void  remove_NetworkConnectionPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_Event::remove_NetworkConnectionPropertyChanged
  } // end of method NetworkListManagerClass::remove_NetworkConnectionPropertyChanged

  .method public hidebysig newslot virtual 
          instance void  add_ConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_Event::add_ConnectivityChanged
  } // end of method NetworkListManagerClass::add_ConnectivityChanged

  .method public hidebysig newslot virtual 
          instance void  remove_ConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_Event::remove_ConnectivityChanged
  } // end of method NetworkListManagerClass::remove_ConnectivityChanged

  .method public hidebysig newslot virtual 
          instance void  add_CostChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_Event::add_CostChanged
  } // end of method NetworkListManagerClass::add_CostChanged

  .method public hidebysig newslot virtual 
          instance void  remove_CostChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_Event::remove_CostChanged
  } // end of method NetworkListManagerClass::remove_CostChanged

  .method public hidebysig newslot virtual 
          instance void  add_DataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_Event::add_DataPlanStatusChanged
  } // end of method NetworkListManagerClass::add_DataPlanStatusChanged

  .method public hidebysig newslot virtual 
          instance void  remove_DataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_Event::remove_DataPlanStatusChanged
  } // end of method NetworkListManagerClass::remove_DataPlanStatusChanged

  .method public hidebysig newslot virtual 
          instance void  add_ConnectionCostChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_Event::add_ConnectionCostChanged
  } // end of method NetworkListManagerClass::add_ConnectionCostChanged

  .method public hidebysig newslot virtual 
          instance void  remove_ConnectionCostChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_Event::remove_ConnectionCostChanged
  } // end of method NetworkListManagerClass::remove_ConnectionCostChanged

  .method public hidebysig newslot virtual 
          instance void  add_ConnectionDataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_Event::add_ConnectionDataPlanStatusChanged
  } // end of method NetworkListManagerClass::add_ConnectionDataPlanStatusChanged

  .method public hidebysig newslot virtual 
          instance void  remove_ConnectionDataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler A_1) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_Event::remove_ConnectionDataPlanStatusChanged
  } // end of method NetworkListManagerClass::remove_ConnectionDataPlanStatusChanged

  .method public hidebysig newslot virtual 
          instance void  RemoteRead([in] string  marshal( lpwstr) pszPropName,
                                    [out] object&  marshal( struct) pVar,
                                    [in] class Vanara.PInvoke.NetListMgr.IErrorLog  marshal( interface ) pErrorLog,
                                    [in] uint32 varType,
                                    [in] object  marshal( iunknown ) pUnkObj) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.IPropertyBag::RemoteRead
  } // end of method NetworkListManagerClass::RemoteRead

  .method public hidebysig newslot virtual 
          instance void  Write([in] string  marshal( lpwstr) pszPropName,
                               [in] object&  marshal( struct) pVar) runtime managed internalcall
  {
    .override Vanara.PInvoke.NetListMgr.IPropertyBag::Write
  } // end of method NetworkListManagerClass::Write

  .event Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler NetworkAdded
  {
    .removeon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::remove_NetworkAdded(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler)
    .addon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::add_NetworkAdded(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler)
  } // end of event NetworkListManagerClass::NetworkAdded
  .event Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler NetworkDeleted
  {
    .removeon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::remove_NetworkDeleted(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler)
    .addon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::add_NetworkDeleted(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler)
  } // end of event NetworkListManagerClass::NetworkDeleted
  .event Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler NetworkConnectivityChanged
  {
    .addon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::add_NetworkConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::remove_NetworkConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler)
  } // end of event NetworkListManagerClass::NetworkConnectivityChanged
  .event Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler NetworkPropertyChanged
  {
    .removeon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::remove_NetworkPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler)
    .addon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::add_NetworkPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler)
  } // end of event NetworkListManagerClass::NetworkPropertyChanged
  .event Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler NetworkConnectionConnectivityChanged
  {
    .addon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::add_NetworkConnectionConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::remove_NetworkConnectionConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler)
  } // end of event NetworkListManagerClass::NetworkConnectionConnectivityChanged
  .event Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler NetworkConnectionPropertyChanged
  {
    .removeon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::remove_NetworkConnectionPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler)
    .addon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::add_NetworkConnectionPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler)
  } // end of event NetworkListManagerClass::NetworkConnectionPropertyChanged
  .event Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler ConnectivityChanged
  {
    .removeon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::remove_ConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler)
    .addon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::add_ConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler)
  } // end of event NetworkListManagerClass::ConnectivityChanged
  .event Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler CostChanged
  {
    .addon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::add_CostChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::remove_CostChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler)
  } // end of event NetworkListManagerClass::CostChanged
  .event Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler DataPlanStatusChanged
  {
    .removeon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::remove_DataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler)
    .addon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::add_DataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler)
  } // end of event NetworkListManagerClass::DataPlanStatusChanged
  .event Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler ConnectionCostChanged
  {
    .removeon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::remove_ConnectionCostChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler)
    .addon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::add_ConnectionCostChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler)
  } // end of event NetworkListManagerClass::ConnectionCostChanged
  .event Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler ConnectionDataPlanStatusChanged
  {
    .addon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::add_ConnectionDataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler)
    .removeon instance void Vanara.PInvoke.NetListMgr.NetworkListManagerClass::remove_ConnectionDataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler)
  } // end of event NetworkListManagerClass::ConnectionDataPlanStatusChanged
  .property bool IsConnectedToInternet()
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 05 00 00 00 00 00 ) 
    .get instance bool Vanara.PInvoke.NetListMgr.NetworkListManagerClass::get_IsConnectedToInternet()
  } // end of property NetworkListManagerClass::IsConnectedToInternet
  .property bool IsConnected()
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 06 00 00 00 00 00 ) 
    .get instance bool Vanara.PInvoke.NetListMgr.NetworkListManagerClass::get_IsConnected()
  } // end of property NetworkListManagerClass::IsConnected
} // end of class Vanara.PInvoke.NetListMgr.NetworkListManagerClass

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.IEnumNetworks
       implements [mscorlib]System.Collections.IEnumerable
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 40 10 00 00 00 00 )                         // ..@.....
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 33 2D 35 37 30 46   // ..$DCB00003-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .method public hidebysig newslot abstract virtual 
          instance class [mscorlib]System.Collections.IEnumerator 
          marshal( custom ("System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a","")) 
          GetEnumerator() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibFuncAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibFuncFlags) = ( 01 00 41 00 00 00 00 00 )                         // ..A.....
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 FC FF FF FF 00 00 ) 
  } // end of method IEnumNetworks::GetEnumerator

  .method public hidebysig newslot abstract virtual 
          instance valuetype [Vanara.PInvoke.Shared]Vanara.PInvoke.HRESULT  Next([in] uint32 celt,
                              [out] class Vanara.PInvoke.NetListMgr.INetwork&  marshal( interface ) rgelt,
                              [out] uint32& pceltFetched) runtime managed preservesig internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 01 00 00 00 00 00 ) 
  } // end of method IEnumNetworks::Next

  .method public hidebysig newslot abstract virtual 
          instance valuetype [Vanara.PInvoke.Shared]Vanara.PInvoke.HRESULT  Skip([in] uint32 celt) runtime managed preservesig internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 02 00 00 00 00 00 ) 
  } // end of method IEnumNetworks::Skip

  .method public hidebysig newslot abstract virtual 
          instance valuetype [Vanara.PInvoke.Shared]Vanara.PInvoke.HRESULT  Reset() runtime managed preservesig internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 03 00 00 00 00 00 ) 
  } // end of method IEnumNetworks::Reset

  .method public hidebysig newslot abstract virtual 
          instance class Vanara.PInvoke.NetListMgr.IEnumNetworks 
          marshal( interface ) 
          Clone() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 04 00 00 00 00 00 ) 
  } // end of method IEnumNetworks::Clone

} // end of class Vanara.PInvoke.NetListMgr.IEnumNetworks

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.NLM_ENUM_NETWORK
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_ENUM_NETWORK NLM_ENUM_NETWORK_CONNECTED = int32(0x00000001)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_ENUM_NETWORK NLM_ENUM_NETWORK_DISCONNECTED = int32(0x00000002)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_ENUM_NETWORK NLM_ENUM_NETWORK_ALL = int32(0x00000003)
} // end of class Vanara.PInvoke.NetListMgr.NLM_ENUM_NETWORK

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.INetwork
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 32 2D 35 37 30 46   // ..$DCB00002-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 40 10 00 00 00 00 )                         // ..@.....
  .method public hidebysig newslot abstract virtual 
          instance string 
          marshal( bstr) 
          GetName() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 01 00 00 00 00 00 ) 
  } // end of method INetwork::GetName

  .method public hidebysig newslot abstract virtual 
          instance void  SetName([in] string  marshal( bstr) szNetworkNewName) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 02 00 00 00 00 00 ) 
  } // end of method INetwork::SetName

  .method public hidebysig newslot abstract virtual 
          instance string 
          marshal( bstr) 
          GetDescription() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 03 00 00 00 00 00 ) 
  } // end of method INetwork::GetDescription

  .method public hidebysig newslot abstract virtual 
          instance void  SetDescription([in] string  marshal( bstr) szDescription) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 04 00 00 00 00 00 ) 
  } // end of method INetwork::SetDescription

  .method public hidebysig newslot abstract virtual 
          instance valuetype [mscorlib]System.Guid 
          GetNetworkId() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 05 00 00 00 00 00 ) 
  } // end of method INetwork::GetNetworkId

  .method public hidebysig newslot abstract virtual 
          instance valuetype Vanara.PInvoke.NetListMgr.NLM_DOMAIN_TYPE 
          GetDomainType() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 06 00 00 00 00 00 ) 
  } // end of method INetwork::GetDomainType

  .method public hidebysig newslot abstract virtual 
          instance class Vanara.PInvoke.NetListMgr.IEnumNetworkConnections 
          marshal( interface ) 
          GetNetworkConnections() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 07 00 00 00 00 00 ) 
  } // end of method INetwork::GetNetworkConnections

  .method public hidebysig newslot abstract virtual 
          instance void  GetTimeCreatedAndConnected([out] uint32& pdwLowDateTimeCreated,
                                                    [out] uint32& pdwHighDateTimeCreated,
                                                    [out] uint32& pdwLowDateTimeConnected,
                                                    [out] uint32& pdwHighDateTimeConnected) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  } // end of method INetwork::GetTimeCreatedAndConnected

  .method public hidebysig newslot specialname abstract virtual 
          instance bool  get_IsConnectedToInternet() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 09 00 00 00 00 00 ) 
  } // end of method INetwork::get_IsConnectedToInternet

  .method public hidebysig newslot specialname abstract virtual 
          instance bool  get_IsConnected() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 0A 00 00 00 00 00 ) 
  } // end of method INetwork::get_IsConnected

  .method public hidebysig newslot abstract virtual 
          instance valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY 
          GetConnectivity() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 0B 00 00 00 00 00 ) 
  } // end of method INetwork::GetConnectivity

  .method public hidebysig newslot abstract virtual 
          instance valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_CATEGORY 
          GetCategory() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 0C 00 00 00 00 00 ) 
  } // end of method INetwork::GetCategory

  .method public hidebysig newslot abstract virtual 
          instance void  SetCategory([in] valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_CATEGORY NewCategory) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 0D 00 00 00 00 00 ) 
  } // end of method INetwork::SetCategory

  .property bool IsConnectedToInternet()
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 09 00 00 00 00 00 ) 
    .get instance bool Vanara.PInvoke.NetListMgr.INetwork::get_IsConnectedToInternet()
  } // end of property INetwork::IsConnectedToInternet
  .property bool IsConnected()
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 0A 00 00 00 00 00 ) 
    .get instance bool Vanara.PInvoke.NetListMgr.INetwork::get_IsConnected()
  } // end of property INetwork::IsConnected
} // end of class Vanara.PInvoke.NetListMgr.INetwork

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.IEnumNetworkConnections
       implements [mscorlib]System.Collections.IEnumerable
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 40 10 00 00 00 00 )                         // ..@.....
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 36 2D 35 37 30 46   // ..$DCB00006-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .method public hidebysig newslot abstract virtual 
          instance class [mscorlib]System.Collections.IEnumerator 
          marshal( custom ("System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a","")) 
          GetEnumerator() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 FC FF FF FF 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibFuncAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibFuncFlags) = ( 01 00 41 00 00 00 00 00 )                         // ..A.....
  } // end of method IEnumNetworkConnections::GetEnumerator

  .method public hidebysig newslot abstract virtual 
          instance valuetype [Vanara.PInvoke.Shared]Vanara.PInvoke.HRESULT Next([in] uint32 celt,
                              [out] class Vanara.PInvoke.NetListMgr.INetworkConnection&  marshal( interface ) rgelt,
                              [out] uint32& pceltFetched) runtime managed preservesig internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 01 00 00 00 00 00 ) 
  } // end of method IEnumNetworkConnections::Next

  .method public hidebysig newslot abstract virtual 
          instance valuetype [Vanara.PInvoke.Shared]Vanara.PInvoke.HRESULT  Skip([in] uint32 celt) runtime managed preservesig internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 02 00 00 00 00 00 ) 
  } // end of method IEnumNetworkConnections::Skip

  .method public hidebysig newslot abstract virtual 
          instance valuetype [Vanara.PInvoke.Shared]Vanara.PInvoke.HRESULT Reset() runtime managed preservesig internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 03 00 00 00 00 00 ) 
  } // end of method IEnumNetworkConnections::Reset

  .method public hidebysig newslot abstract virtual 
          instance class Vanara.PInvoke.NetListMgr.IEnumNetworkConnections 
          marshal( interface ) 
          Clone() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 04 00 00 00 00 00 ) 
  } // end of method IEnumNetworkConnections::Clone

} // end of class Vanara.PInvoke.NetListMgr.IEnumNetworkConnections

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.INetworkConnection
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 35 2D 35 37 30 46   // ..$DCB00005-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 40 10 00 00 00 00 )                         // ..@.....
  .method public hidebysig newslot abstract virtual 
          instance class Vanara.PInvoke.NetListMgr.INetwork 
          marshal( interface ) 
          GetNetwork() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 01 00 00 00 00 00 ) 
  } // end of method INetworkConnection::GetNetwork

  .method public hidebysig newslot specialname abstract virtual 
          instance bool  get_IsConnectedToInternet() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 02 00 00 00 00 00 ) 
  } // end of method INetworkConnection::get_IsConnectedToInternet

  .method public hidebysig newslot specialname abstract virtual 
          instance bool  get_IsConnected() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 03 00 00 00 00 00 ) 
  } // end of method INetworkConnection::get_IsConnected

  .method public hidebysig newslot abstract virtual 
          instance valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY 
          GetConnectivity() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 04 00 00 00 00 00 ) 
  } // end of method INetworkConnection::GetConnectivity

  .method public hidebysig newslot abstract virtual 
          instance valuetype [mscorlib]System.Guid 
          GetConnectionId() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 05 00 00 00 00 00 ) 
  } // end of method INetworkConnection::GetConnectionId

  .method public hidebysig newslot abstract virtual 
          instance valuetype [mscorlib]System.Guid 
          GetAdapterId() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 06 00 00 00 00 00 ) 
  } // end of method INetworkConnection::GetAdapterId

  .method public hidebysig newslot abstract virtual 
          instance valuetype Vanara.PInvoke.NetListMgr.NLM_DOMAIN_TYPE 
          GetDomainType() runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 07 00 00 00 00 00 ) 
  } // end of method INetworkConnection::GetDomainType

  .property bool IsConnectedToInternet()
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 02 00 00 00 00 00 ) 
    .get instance bool Vanara.PInvoke.NetListMgr.INetworkConnection::get_IsConnectedToInternet()
  } // end of property INetworkConnection::IsConnectedToInternet
  .property bool IsConnected()
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 03 00 00 00 00 00 ) 
    .get instance bool Vanara.PInvoke.NetListMgr.INetworkConnection::get_IsConnected()
  } // end of property INetworkConnection::IsConnected
} // end of class Vanara.PInvoke.NetListMgr.INetworkConnection

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY NLM_CONNECTIVITY_DISCONNECTED = int32(0x00000000)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY NLM_CONNECTIVITY_IPV4_NOTRAFFIC = int32(0x00000001)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY NLM_CONNECTIVITY_IPV6_NOTRAFFIC = int32(0x00000002)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY NLM_CONNECTIVITY_IPV4_SUBNET = int32(0x00000010)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY NLM_CONNECTIVITY_IPV4_LOCALNETWORK = int32(0x00000020)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY NLM_CONNECTIVITY_IPV4_INTERNET = int32(0x00000040)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY NLM_CONNECTIVITY_IPV6_SUBNET = int32(0x00000100)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY NLM_CONNECTIVITY_IPV6_LOCALNETWORK = int32(0x00000200)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY NLM_CONNECTIVITY_IPV6_INTERNET = int32(0x00000400)
} // end of class Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY

.class public sequential ansi sealed beforefieldinit Vanara.PInvoke.NetListMgr.NLM_SIMULATED_PROFILE_INFO
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public marshal(fixed sysstring [256]) string ProfileName
  .field public valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST cost
  .field public uint32 UsageInMegabytes
  .field public uint32 DataLimitInMegabytes
} // end of class Vanara.PInvoke.NetListMgr.NLM_SIMULATED_PROFILE_INFO

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.NLM_NETWORK_CLASS
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_CLASS NLM_NETWORK_IDENTIFYING = int32(0x00000001)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_CLASS NLM_NETWORK_IDENTIFIED = int32(0x00000002)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_CLASS NLM_NETWORK_UNIDENTIFIED = int32(0x00000003)
} // end of class Vanara.PInvoke.NetListMgr.NLM_NETWORK_CLASS

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.NLM_INTERNET_CONNECTIVITY
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_INTERNET_CONNECTIVITY NLM_INTERNET_CONNECTIVITY_WEBHIJACK = int32(0x00000001)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_INTERNET_CONNECTIVITY NLM_INTERNET_CONNECTIVITY_PROXIED = int32(0x00000002)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_INTERNET_CONNECTIVITY NLM_INTERNET_CONNECTIVITY_CORPORATE = int32(0x00000004)
} // end of class Vanara.PInvoke.NetListMgr.NLM_INTERNET_CONNECTIVITY

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.NLM_NETWORK_PROPERTY_CHANGE
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_PROPERTY_CHANGE NLM_NETWORK_PROPERTY_CHANGE_CONNECTION = int32(0x00000001)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_PROPERTY_CHANGE NLM_NETWORK_PROPERTY_CHANGE_DESCRIPTION = int32(0x00000002)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_PROPERTY_CHANGE NLM_NETWORK_PROPERTY_CHANGE_NAME = int32(0x00000004)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_PROPERTY_CHANGE NLM_NETWORK_PROPERTY_CHANGE_ICON = int32(0x00000008)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_PROPERTY_CHANGE NLM_NETWORK_PROPERTY_CHANGE_CATEGORY_VALUE = int32(0x00000010)
} // end of class Vanara.PInvoke.NetListMgr.NLM_NETWORK_PROPERTY_CHANGE

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler
       extends [mscorlib]System.MulticastDelegate
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor(object A_1,
                               native uint A_2) runtime managed
  {
  } // end of method INetworkEvents_NetworkAddedEventHandler::.ctor

  .method public virtual instance void  Invoke([in] valuetype [mscorlib]System.Guid networkId) runtime managed
  {
  } // end of method INetworkEvents_NetworkAddedEventHandler::Invoke

} // end of class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler
       extends [mscorlib]System.MulticastDelegate
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor(object A_1,
                               native uint A_2) runtime managed
  {
  } // end of method INetworkEvents_NetworkDeletedEventHandler::.ctor

  .method public virtual instance void  Invoke([in] valuetype [mscorlib]System.Guid networkId) runtime managed
  {
  } // end of method INetworkEvents_NetworkDeletedEventHandler::Invoke

} // end of class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler
       extends [mscorlib]System.MulticastDelegate
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor(object A_1,
                               native uint A_2) runtime managed
  {
  } // end of method INetworkEvents_NetworkConnectivityChangedEventHandler::.ctor

  .method public virtual instance void  Invoke([in] valuetype [mscorlib]System.Guid networkId,
                                               [in] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY newConnectivity) runtime managed
  {
  } // end of method INetworkEvents_NetworkConnectivityChangedEventHandler::Invoke

} // end of class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler
       extends [mscorlib]System.MulticastDelegate
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor(object A_1,
                               native uint A_2) runtime managed
  {
  } // end of method INetworkEvents_NetworkPropertyChangedEventHandler::.ctor

  .method public virtual instance void  Invoke([in] valuetype [mscorlib]System.Guid networkId,
                                               [in] valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_PROPERTY_CHANGE Flags) runtime managed
  {
  } // end of method INetworkEvents_NetworkPropertyChangedEventHandler::Invoke

} // end of class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST NLM_CONNECTION_COST_UNKNOWN = int32(0x00000000)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST NLM_CONNECTION_COST_UNRESTRICTED = int32(0x00000001)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST NLM_CONNECTION_COST_FIXED = int32(0x00000002)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST NLM_CONNECTION_COST_VARIABLE = int32(0x00000004)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST NLM_CONNECTION_COST_OVERDATALIMIT = int32(0x00010000)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST NLM_CONNECTION_COST_CONGESTED = int32(0x00020000)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST NLM_CONNECTION_COST_ROAMING = int32(0x00040000)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST NLM_CONNECTION_COST_APPROACHINGDATALIMIT = int32(0x00080000)
} // end of class Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.INetworkConnectionCost
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 43 42 30 30 30 30 41 2D 35 37 30 46   // ..$DCB0000A-570F
                                                                                                  2D 34 41 39 42 2D 38 44 36 39 2D 31 39 39 46 44   // -4A9B-8D69-199FD
                                                                                                  42 41 35 37 32 33 42 00 00 )                      // BA5723B..
  .method public hidebysig newslot abstract virtual 
          instance valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST  GetCost() runtime managed internalcall
  {
  } // end of method INetworkConnectionCost::GetCost

  .method public hidebysig newslot abstract virtual 
          instance valuetype Vanara.PInvoke.NetListMgr.NLM_DATAPLAN_STATUS  GetDataPlanStatus() runtime managed internalcall
  {
  } // end of method INetworkConnectionCost::GetDataPlanStatus

} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionCost

.class public sequential ansi sealed beforefieldinit Vanara.PInvoke.NetListMgr.NLM_DATAPLAN_STATUS
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public valuetype [mscorlib]System.Guid InterfaceGuid
  .field public valuetype Vanara.PInvoke.NetListMgr.NLM_USAGE_DATA UsageData
  .field public uint32 DataLimitInMegabytes
  .field public uint32 InboundBandwidthInKbps
  .field public uint32 OutboundBandwidthInKbps
  .field public valuetype [mscorlib]System.Runtime.InteropServices.ComTypes.FILETIME NextBillingCycle
  .field public uint32 MaxTransferSizeInMegabytes
  .field public uint32 Reserved
} // end of class Vanara.PInvoke.NetListMgr.NLM_DATAPLAN_STATUS

.class public sequential ansi sealed beforefieldinit Vanara.PInvoke.NetListMgr.NLM_USAGE_DATA
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public uint32 UsageInMegabytes
  .field public valuetype [mscorlib]System.Runtime.InteropServices.ComTypes.FILETIME LastSyncTime
} // end of class Vanara.PInvoke.NetListMgr.NLM_USAGE_DATA

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.NLM_DOMAIN_TYPE
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_DOMAIN_TYPE NLM_DOMAIN_TYPE_NON_DOMAIN_NETWORK = int32(0x00000000)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_DOMAIN_TYPE NLM_DOMAIN_TYPE_DOMAIN_NETWORK = int32(0x00000001)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_DOMAIN_TYPE NLM_DOMAIN_TYPE_DOMAIN_AUTHENTICATED = int32(0x00000002)
} // end of class Vanara.PInvoke.NetListMgr.NLM_DOMAIN_TYPE

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.NLM_NETWORK_CATEGORY
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_CATEGORY NLM_NETWORK_CATEGORY_PUBLIC = int32(0x00000000)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_CATEGORY NLM_NETWORK_CATEGORY_PRIVATE = int32(0x00000001)
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_CATEGORY NLM_NETWORK_CATEGORY_DOMAIN_AUTHENTICATED = int32(0x00000002)
} // end of class Vanara.PInvoke.NetListMgr.NLM_NETWORK_CATEGORY

.class public sequential ansi sealed beforefieldinit Vanara.PInvoke.NetListMgr.NLM_SOCKADDR
       extends [mscorlib]System.ValueType
{
  .pack 1
  .size 0
  .field public  marshal( fixed array [128]) uint8[] data
} // end of class Vanara.PInvoke.NetListMgr.NLM_SOCKADDR

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.NLM_CONNECTION_PROPERTY_CHANGE
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_PROPERTY_CHANGE NLM_CONNECTION_PROPERTY_CHANGE_AUTHENTICATION = int32(0x00000001)
} // end of class Vanara.PInvoke.NetListMgr.NLM_CONNECTION_PROPERTY_CHANGE

.class interface public abstract auto ansi import Vanara.PInvoke.NetListMgr.IErrorLog
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 33 31 32 37 43 41 34 30 2D 34 34 36 45   // ..$3127CA40-446E
                                                                                                  2D 31 31 43 45 2D 38 31 33 35 2D 30 30 41 41 30   // -11CE-8135-00AA0
                                                                                                  30 34 42 42 38 35 31 00 00 )                      // 04BB851..
  .method public hidebysig newslot abstract virtual 
          instance void  AddError([in] string  marshal( lpwstr) pszPropName,
                                  [in] valuetype [stdole]stdole.EXCEPINFO& pExcepInfo) runtime managed internalcall
  {
  } // end of method IErrorLog::AddError

} // end of class Vanara.PInvoke.NetListMgr.IErrorLog

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler
       extends [mscorlib]System.MulticastDelegate
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor(object A_1,
                               native uint A_2) runtime managed
  {
  } // end of method INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler::.ctor

  .method public virtual instance void  Invoke([in] valuetype [mscorlib]System.Guid connectionId,
                                               [in] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY newConnectivity) runtime managed
  {
  } // end of method INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler::Invoke

} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler
       extends [mscorlib]System.MulticastDelegate
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor(object A_1,
                               native uint A_2) runtime managed
  {
  } // end of method INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler::.ctor

  .method public virtual instance void  Invoke([in] valuetype [mscorlib]System.Guid connectionId,
                                               [in] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_PROPERTY_CHANGE Flags) runtime managed
  {
  } // end of method INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler::Invoke

} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler
       extends [mscorlib]System.MulticastDelegate
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor(object A_1,
                               native uint A_2) runtime managed
  {
  } // end of method INetworkListManagerEvents_ConnectivityChangedEventHandler::.ctor

  .method public virtual instance void  Invoke([in] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY newConnectivity) runtime managed
  {
  } // end of method INetworkListManagerEvents_ConnectivityChangedEventHandler::Invoke

} // end of class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler
       extends [mscorlib]System.MulticastDelegate
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor(object A_1,
                               native uint A_2) runtime managed
  {
  } // end of method INetworkCostManagerEvents_CostChangedEventHandler::.ctor

  .method public virtual instance void  Invoke([in] valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST newCost,
                                               [in] valuetype Vanara.PInvoke.NetListMgr.NLM_SOCKADDR& pDestAddr) runtime managed
  {
  } // end of method INetworkCostManagerEvents_CostChangedEventHandler::Invoke

} // end of class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler
       extends [mscorlib]System.MulticastDelegate
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor(object A_1,
                               native uint A_2) runtime managed
  {
  } // end of method INetworkCostManagerEvents_DataPlanStatusChangedEventHandler::.ctor

  .method public virtual instance void  Invoke([in] valuetype Vanara.PInvoke.NetListMgr.NLM_SOCKADDR& pDestAddr) runtime managed
  {
  } // end of method INetworkCostManagerEvents_DataPlanStatusChangedEventHandler::Invoke

} // end of class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler
       extends [mscorlib]System.MulticastDelegate
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor(object A_1,
                               native uint A_2) runtime managed
  {
  } // end of method INetworkConnectionCostEvents_ConnectionCostChangedEventHandler::.ctor

  .method public virtual instance void  Invoke([in] valuetype [mscorlib]System.Guid connectionId,
                                               [in] uint32 newCost) runtime managed
  {
  } // end of method INetworkConnectionCostEvents_ConnectionCostChangedEventHandler::Invoke

} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler
       extends [mscorlib]System.MulticastDelegate
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor(object A_1,
                               native uint A_2) runtime managed
  {
  } // end of method INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler::.ctor

  .method public virtual instance void  Invoke([in] valuetype [mscorlib]System.Guid connectionId) runtime managed
  {
  } // end of method INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler::Invoke

} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper
       extends [mscorlib]System.Object
       implements Vanara.PInvoke.NetListMgr.INetworkEvents
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ClassInterfaceType) = ( 01 00 00 00 00 00 00 00 ) 
  .field public class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler m_NetworkAddedDelegate
  .field public class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler m_NetworkDeletedDelegate
  .field public class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler m_NetworkConnectivityChangedDelegate
  .field public class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler m_NetworkPropertyChangedDelegate
  .field public int32 m_dwCookie
  .method public virtual instance void  NetworkAdded(valuetype [mscorlib]System.Guid A_1) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  2
    IL_0000:  ldarg      0
    IL_0004:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkAddedDelegate
    IL_0009:  brfalse    IL_0021

    IL_000e:  ldarg      0
    IL_0012:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkAddedDelegate
    IL_0017:  ldarg      A_1
    IL_001b:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler::Invoke(valuetype [mscorlib]System.Guid)
    IL_0020:  ret

    IL_0021:  ret
  } // end of method INetworkEvents_SinkHelper::NetworkAdded

  .method public virtual instance void  NetworkDeleted(valuetype [mscorlib]System.Guid A_1) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  2
    IL_0000:  ldarg      0
    IL_0004:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkDeletedDelegate
    IL_0009:  brfalse    IL_0021

    IL_000e:  ldarg      0
    IL_0012:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkDeletedDelegate
    IL_0017:  ldarg      A_1
    IL_001b:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler::Invoke(valuetype [mscorlib]System.Guid)
    IL_0020:  ret

    IL_0021:  ret
  } // end of method INetworkEvents_SinkHelper::NetworkDeleted

  .method public virtual instance void  NetworkConnectivityChanged(valuetype [mscorlib]System.Guid A_1,
                                                                   valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY A_2) cil managed
  {
    // Code size       38 (0x26)
    .maxstack  3
    IL_0000:  ldarg      0
    IL_0004:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkConnectivityChangedDelegate
    IL_0009:  brfalse    IL_0025

    IL_000e:  ldarg      0
    IL_0012:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkConnectivityChangedDelegate
    IL_0017:  ldarg      A_1
    IL_001b:  ldarg      A_2
    IL_001f:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler::Invoke(valuetype [mscorlib]System.Guid,
                                                                                                                               valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY)
    IL_0024:  ret

    IL_0025:  ret
  } // end of method INetworkEvents_SinkHelper::NetworkConnectivityChanged

  .method public virtual instance void  NetworkPropertyChanged(valuetype [mscorlib]System.Guid A_1,
                                                               valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_PROPERTY_CHANGE A_2) cil managed
  {
    // Code size       38 (0x26)
    .maxstack  3
    IL_0000:  ldarg      0
    IL_0004:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkPropertyChangedDelegate
    IL_0009:  brfalse    IL_0025

    IL_000e:  ldarg      0
    IL_0012:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkPropertyChangedDelegate
    IL_0017:  ldarg      A_1
    IL_001b:  ldarg      A_2
    IL_001f:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler::Invoke(valuetype [mscorlib]System.Guid,
                                                                                                                           valuetype Vanara.PInvoke.NetListMgr.NLM_NETWORK_PROPERTY_CHANGE)
    IL_0024:  ret

    IL_0025:  ret
  } // end of method INetworkEvents_SinkHelper::NetworkPropertyChanged

  .method assembly specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       64 (0x40)
    .maxstack  4
    IL_0000:  ldarg      0
    IL_0004:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0009:  ldarg      0
    IL_000d:  ldc.i4     0x0
    IL_0012:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_dwCookie
    IL_0017:  ldarg      0
    IL_001b:  ldnull
    IL_001c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkAddedDelegate
    IL_0021:  ldarg      0
    IL_0025:  ldnull
    IL_0026:  stfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkDeletedDelegate
    IL_002b:  ldarg      0
    IL_002f:  ldnull
    IL_0030:  stfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkConnectivityChangedDelegate
    IL_0035:  ldarg      0
    IL_0039:  ldnull
    IL_003a:  stfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkPropertyChangedDelegate
    IL_003f:  ret
  } // end of method INetworkEvents_SinkHelper::.ctor

} // end of class Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper

.class private auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider
       extends [mscorlib]System.Object
       implements Vanara.PInvoke.NetListMgr.INetworkEvents_Event,
                  [mscorlib]System.IDisposable
{
  .field private class [mscorlib]System.WeakReference m_wkConnectionPointContainer
  .field private class [mscorlib]System.Collections.ArrayList m_aEventSinkHelpers
  .field private class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint m_ConnectionPoint
  .method private instance void  Init() cil managed
  {
    // Code size       271 (0x10f)
    .maxstack  5
    .locals init (class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint V_0,
             valuetype [mscorlib]System.Guid V_1,
             uint8[] V_2)
    IL_0000:  ldnull
    IL_0001:  stloc.0
    IL_0002:  ldc.i4     0x10
    IL_0007:  newarr     [mscorlib]System.Byte
    IL_000c:  stloc.2
    IL_000d:  ldloc.2
    IL_000e:  ldc.i4     0x0
    IL_0013:  ldc.i4     0x4
    IL_0018:  stelem.i1
    IL_0019:  ldloc.2
    IL_001a:  ldc.i4     0x1
    IL_001f:  ldc.i4     0x0
    IL_0024:  stelem.i1
    IL_0025:  ldloc.2
    IL_0026:  ldc.i4     0x2
    IL_002b:  ldc.i4     0xb0
    IL_0030:  stelem.i1
    IL_0031:  ldloc.2
    IL_0032:  ldc.i4     0x3
    IL_0037:  ldc.i4     0xdc
    IL_003c:  stelem.i1
    IL_003d:  ldloc.2
    IL_003e:  ldc.i4     0x4
    IL_0043:  ldc.i4     0xf
    IL_0048:  stelem.i1
    IL_0049:  ldloc.2
    IL_004a:  ldc.i4     0x5
    IL_004f:  ldc.i4     0x57
    IL_0054:  stelem.i1
    IL_0055:  ldloc.2
    IL_0056:  ldc.i4     0x6
    IL_005b:  ldc.i4     0x9b
    IL_0060:  stelem.i1
    IL_0061:  ldloc.2
    IL_0062:  ldc.i4     0x7
    IL_0067:  ldc.i4     0x4a
    IL_006c:  stelem.i1
    IL_006d:  ldloc.2
    IL_006e:  ldc.i4     0x8
    IL_0073:  ldc.i4     0x8d
    IL_0078:  stelem.i1
    IL_0079:  ldloc.2
    IL_007a:  ldc.i4     0x9
    IL_007f:  ldc.i4     0x69
    IL_0084:  stelem.i1
    IL_0085:  ldloc.2
    IL_0086:  ldc.i4     0xa
    IL_008b:  ldc.i4     0x19
    IL_0090:  stelem.i1
    IL_0091:  ldloc.2
    IL_0092:  ldc.i4     0xb
    IL_0097:  ldc.i4     0x9f
    IL_009c:  stelem.i1
    IL_009d:  ldloc.2
    IL_009e:  ldc.i4     0xc
    IL_00a3:  ldc.i4     0xdb
    IL_00a8:  stelem.i1
    IL_00a9:  ldloc.2
    IL_00aa:  ldc.i4     0xd
    IL_00af:  ldc.i4     0xa5
    IL_00b4:  stelem.i1
    IL_00b5:  ldloc.2
    IL_00b6:  ldc.i4     0xe
    IL_00bb:  ldc.i4     0x72
    IL_00c0:  stelem.i1
    IL_00c1:  ldloc.2
    IL_00c2:  ldc.i4     0xf
    IL_00c7:  ldc.i4     0x3b
    IL_00cc:  stelem.i1
    IL_00cd:  ldloca.s   V_1
    IL_00cf:  ldloc.2
    IL_00d0:  call       instance void [mscorlib]System.Guid::.ctor(uint8[])
    IL_00d5:  ldarg      0
    IL_00d9:  ldfld      class [mscorlib]System.WeakReference Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_wkConnectionPointContainer
    IL_00de:  callvirt   instance object [mscorlib]System.WeakReference::get_Target()
    IL_00e3:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer
    IL_00e8:  ldloca.s   V_1
    IL_00ea:  ldloca.s   V_0
    IL_00ec:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer::FindConnectionPoint(valuetype [mscorlib]System.Guid&,
                                                                                                                                        class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint&)
    IL_00f1:  ldarg      0
    IL_00f5:  ldloc.0
    IL_00f6:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint
    IL_00fb:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
    IL_0100:  ldarg      0
    IL_0104:  newobj     instance void [mscorlib]System.Collections.ArrayList::.ctor()
    IL_0109:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
    IL_010e:  ret
  } // end of method INetworkEvents_EventProvider::Init

  .method public virtual instance void  add_NetworkAdded(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler A_1) cil managed
  {
    // Code size       121 (0x79)
    .maxstack  6
    .locals init (class Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper V_0,
             int32 V_1,
             bool V_2)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_2
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_0014:  brtrue     IL_0022

      IL_0019:  ldarg      0
      IL_001d:  call       instance void Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::Init()
      IL_0022:  newobj     instance void Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::.ctor()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4.0
      IL_0029:  stloc.1
      IL_002a:  ldarg      0
      IL_002e:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_0033:  ldloc.0
      IL_0034:  castclass  [mscorlib]System.Object
      IL_0039:  ldloca.s   V_1
      IL_003b:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Advise(object,
                                                                                                                    int32&)
      IL_0040:  ldloc.0
      IL_0041:  ldloc.1
      IL_0042:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_dwCookie
      IL_0047:  ldloc.0
      IL_0048:  ldarg      A_1
      IL_004c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkAddedDelegate
      IL_0051:  ldarg      0
      IL_0055:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_005a:  ldloc.0
      IL_005b:  castclass  [mscorlib]System.Object
      IL_0060:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::Add(object)
      IL_0065:  pop
      IL_0066:  leave      IL_0078

    }  // end .try
    finally
    {
      IL_006b:  ldloc.2
      IL_006c:  brfalse.s  IL_0077

      IL_006e:  ldarg      0
      IL_0072:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0077:  endfinally
    }  // end handler
    IL_0078:  ret
  } // end of method INetworkEvents_EventProvider::add_NetworkAdded

  .method public virtual instance void  remove_NetworkAdded(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler A_1) cil managed
  {
    // Code size       246 (0xf6)
    .maxstack  6
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_3
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0014:  brfalse    IL_00e3

      IL_0019:  ldarg      0
      IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4     0x0
      IL_002d:  stloc.1
      IL_002e:  ldc.i4     0x0
      IL_0033:  ldloc.0
      IL_0034:  bge        IL_00e3

      IL_0039:  ldarg      0
      IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0042:  ldloc.1
      IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
      IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper
      IL_004d:  stloc.2
      IL_004e:  ldloc.2
      IL_004f:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkAddedDelegate
      IL_0054:  ldnull
      IL_0055:  beq        IL_00d4

      IL_005a:  ldloc.2
      IL_005b:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkAddedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkAddedDelegate
      IL_0060:  ldarg      A_1
      IL_0064:  castclass  [mscorlib]System.Object
      IL_0069:  callvirt   instance bool [mscorlib]System.Delegate::Equals(object)
      IL_006e:  ldc.i4     0xff
      IL_0073:  and
      IL_0074:  ldc.i4     0x0
      IL_0079:  beq        IL_00d4

      IL_007e:  ldarg      0
      IL_0082:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0087:  ldloc.1
      IL_0088:  callvirt   instance void [mscorlib]System.Collections.ArrayList::RemoveAt(int32)
      IL_008d:  ldarg      0
      IL_0091:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_0096:  ldloc.2
      IL_0097:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_dwCookie
      IL_009c:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
      IL_00a1:  ldloc.0
      IL_00a2:  ldc.i4     0x1
      IL_00a7:  bgt        IL_00e3

      IL_00ac:  ldarg      0
      IL_00b0:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_00b5:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
      IL_00ba:  pop
      IL_00bb:  ldarg      0
      IL_00bf:  ldnull
      IL_00c0:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_00c5:  ldarg      0
      IL_00c9:  ldnull
      IL_00ca:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_00cf:  br         IL_00e3

      IL_00d4:  ldloc.1
      IL_00d5:  ldc.i4     0x1
      IL_00da:  add
      IL_00db:  stloc.1
      IL_00dc:  ldloc.1
      IL_00dd:  ldloc.0
      IL_00de:  blt        IL_0039

      IL_00e3:  leave      IL_00f5

    }  // end .try
    finally
    {
      IL_00e8:  ldloc.3
      IL_00e9:  brfalse.s  IL_00f4

      IL_00eb:  ldarg      0
      IL_00ef:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00f4:  endfinally
    }  // end handler
    IL_00f5:  ret
  } // end of method INetworkEvents_EventProvider::remove_NetworkAdded

  .method public virtual instance void  add_NetworkDeleted(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler A_1) cil managed
  {
    // Code size       121 (0x79)
    .maxstack  6
    .locals init (class Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper V_0,
             int32 V_1,
             bool V_2)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_2
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_0014:  brtrue     IL_0022

      IL_0019:  ldarg      0
      IL_001d:  call       instance void Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::Init()
      IL_0022:  newobj     instance void Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::.ctor()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4.0
      IL_0029:  stloc.1
      IL_002a:  ldarg      0
      IL_002e:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_0033:  ldloc.0
      IL_0034:  castclass  [mscorlib]System.Object
      IL_0039:  ldloca.s   V_1
      IL_003b:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Advise(object,
                                                                                                                    int32&)
      IL_0040:  ldloc.0
      IL_0041:  ldloc.1
      IL_0042:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_dwCookie
      IL_0047:  ldloc.0
      IL_0048:  ldarg      A_1
      IL_004c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkDeletedDelegate
      IL_0051:  ldarg      0
      IL_0055:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_005a:  ldloc.0
      IL_005b:  castclass  [mscorlib]System.Object
      IL_0060:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::Add(object)
      IL_0065:  pop
      IL_0066:  leave      IL_0078

    }  // end .try
    finally
    {
      IL_006b:  ldloc.2
      IL_006c:  brfalse.s  IL_0077

      IL_006e:  ldarg      0
      IL_0072:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0077:  endfinally
    }  // end handler
    IL_0078:  ret
  } // end of method INetworkEvents_EventProvider::add_NetworkDeleted

  .method public virtual instance void  remove_NetworkDeleted(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler A_1) cil managed
  {
    // Code size       246 (0xf6)
    .maxstack  6
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_3
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0014:  brfalse    IL_00e3

      IL_0019:  ldarg      0
      IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4     0x0
      IL_002d:  stloc.1
      IL_002e:  ldc.i4     0x0
      IL_0033:  ldloc.0
      IL_0034:  bge        IL_00e3

      IL_0039:  ldarg      0
      IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0042:  ldloc.1
      IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
      IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper
      IL_004d:  stloc.2
      IL_004e:  ldloc.2
      IL_004f:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkDeletedDelegate
      IL_0054:  ldnull
      IL_0055:  beq        IL_00d4

      IL_005a:  ldloc.2
      IL_005b:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkDeletedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkDeletedDelegate
      IL_0060:  ldarg      A_1
      IL_0064:  castclass  [mscorlib]System.Object
      IL_0069:  callvirt   instance bool [mscorlib]System.Delegate::Equals(object)
      IL_006e:  ldc.i4     0xff
      IL_0073:  and
      IL_0074:  ldc.i4     0x0
      IL_0079:  beq        IL_00d4

      IL_007e:  ldarg      0
      IL_0082:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0087:  ldloc.1
      IL_0088:  callvirt   instance void [mscorlib]System.Collections.ArrayList::RemoveAt(int32)
      IL_008d:  ldarg      0
      IL_0091:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_0096:  ldloc.2
      IL_0097:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_dwCookie
      IL_009c:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
      IL_00a1:  ldloc.0
      IL_00a2:  ldc.i4     0x1
      IL_00a7:  bgt        IL_00e3

      IL_00ac:  ldarg      0
      IL_00b0:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_00b5:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
      IL_00ba:  pop
      IL_00bb:  ldarg      0
      IL_00bf:  ldnull
      IL_00c0:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_00c5:  ldarg      0
      IL_00c9:  ldnull
      IL_00ca:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_00cf:  br         IL_00e3

      IL_00d4:  ldloc.1
      IL_00d5:  ldc.i4     0x1
      IL_00da:  add
      IL_00db:  stloc.1
      IL_00dc:  ldloc.1
      IL_00dd:  ldloc.0
      IL_00de:  blt        IL_0039

      IL_00e3:  leave      IL_00f5

    }  // end .try
    finally
    {
      IL_00e8:  ldloc.3
      IL_00e9:  brfalse.s  IL_00f4

      IL_00eb:  ldarg      0
      IL_00ef:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00f4:  endfinally
    }  // end handler
    IL_00f5:  ret
  } // end of method INetworkEvents_EventProvider::remove_NetworkDeleted

  .method public virtual instance void  add_NetworkConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler A_1) cil managed
  {
    // Code size       121 (0x79)
    .maxstack  6
    .locals init (class Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper V_0,
             int32 V_1,
             bool V_2)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_2
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_0014:  brtrue     IL_0022

      IL_0019:  ldarg      0
      IL_001d:  call       instance void Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::Init()
      IL_0022:  newobj     instance void Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::.ctor()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4.0
      IL_0029:  stloc.1
      IL_002a:  ldarg      0
      IL_002e:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_0033:  ldloc.0
      IL_0034:  castclass  [mscorlib]System.Object
      IL_0039:  ldloca.s   V_1
      IL_003b:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Advise(object,
                                                                                                                    int32&)
      IL_0040:  ldloc.0
      IL_0041:  ldloc.1
      IL_0042:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_dwCookie
      IL_0047:  ldloc.0
      IL_0048:  ldarg      A_1
      IL_004c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkConnectivityChangedDelegate
      IL_0051:  ldarg      0
      IL_0055:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_005a:  ldloc.0
      IL_005b:  castclass  [mscorlib]System.Object
      IL_0060:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::Add(object)
      IL_0065:  pop
      IL_0066:  leave      IL_0078

    }  // end .try
    finally
    {
      IL_006b:  ldloc.2
      IL_006c:  brfalse.s  IL_0077

      IL_006e:  ldarg      0
      IL_0072:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0077:  endfinally
    }  // end handler
    IL_0078:  ret
  } // end of method INetworkEvents_EventProvider::add_NetworkConnectivityChanged

  .method public virtual instance void  remove_NetworkConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler A_1) cil managed
  {
    // Code size       246 (0xf6)
    .maxstack  6
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_3
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0014:  brfalse    IL_00e3

      IL_0019:  ldarg      0
      IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4     0x0
      IL_002d:  stloc.1
      IL_002e:  ldc.i4     0x0
      IL_0033:  ldloc.0
      IL_0034:  bge        IL_00e3

      IL_0039:  ldarg      0
      IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0042:  ldloc.1
      IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
      IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper
      IL_004d:  stloc.2
      IL_004e:  ldloc.2
      IL_004f:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkConnectivityChangedDelegate
      IL_0054:  ldnull
      IL_0055:  beq        IL_00d4

      IL_005a:  ldloc.2
      IL_005b:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkConnectivityChangedDelegate
      IL_0060:  ldarg      A_1
      IL_0064:  castclass  [mscorlib]System.Object
      IL_0069:  callvirt   instance bool [mscorlib]System.Delegate::Equals(object)
      IL_006e:  ldc.i4     0xff
      IL_0073:  and
      IL_0074:  ldc.i4     0x0
      IL_0079:  beq        IL_00d4

      IL_007e:  ldarg      0
      IL_0082:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0087:  ldloc.1
      IL_0088:  callvirt   instance void [mscorlib]System.Collections.ArrayList::RemoveAt(int32)
      IL_008d:  ldarg      0
      IL_0091:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_0096:  ldloc.2
      IL_0097:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_dwCookie
      IL_009c:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
      IL_00a1:  ldloc.0
      IL_00a2:  ldc.i4     0x1
      IL_00a7:  bgt        IL_00e3

      IL_00ac:  ldarg      0
      IL_00b0:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_00b5:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
      IL_00ba:  pop
      IL_00bb:  ldarg      0
      IL_00bf:  ldnull
      IL_00c0:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_00c5:  ldarg      0
      IL_00c9:  ldnull
      IL_00ca:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_00cf:  br         IL_00e3

      IL_00d4:  ldloc.1
      IL_00d5:  ldc.i4     0x1
      IL_00da:  add
      IL_00db:  stloc.1
      IL_00dc:  ldloc.1
      IL_00dd:  ldloc.0
      IL_00de:  blt        IL_0039

      IL_00e3:  leave      IL_00f5

    }  // end .try
    finally
    {
      IL_00e8:  ldloc.3
      IL_00e9:  brfalse.s  IL_00f4

      IL_00eb:  ldarg      0
      IL_00ef:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00f4:  endfinally
    }  // end handler
    IL_00f5:  ret
  } // end of method INetworkEvents_EventProvider::remove_NetworkConnectivityChanged

  .method public virtual instance void  add_NetworkPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler A_1) cil managed
  {
    // Code size       121 (0x79)
    .maxstack  6
    .locals init (class Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper V_0,
             int32 V_1,
             bool V_2)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_2
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_0014:  brtrue     IL_0022

      IL_0019:  ldarg      0
      IL_001d:  call       instance void Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::Init()
      IL_0022:  newobj     instance void Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::.ctor()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4.0
      IL_0029:  stloc.1
      IL_002a:  ldarg      0
      IL_002e:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_0033:  ldloc.0
      IL_0034:  castclass  [mscorlib]System.Object
      IL_0039:  ldloca.s   V_1
      IL_003b:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Advise(object,
                                                                                                                    int32&)
      IL_0040:  ldloc.0
      IL_0041:  ldloc.1
      IL_0042:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_dwCookie
      IL_0047:  ldloc.0
      IL_0048:  ldarg      A_1
      IL_004c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkPropertyChangedDelegate
      IL_0051:  ldarg      0
      IL_0055:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_005a:  ldloc.0
      IL_005b:  castclass  [mscorlib]System.Object
      IL_0060:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::Add(object)
      IL_0065:  pop
      IL_0066:  leave      IL_0078

    }  // end .try
    finally
    {
      IL_006b:  ldloc.2
      IL_006c:  brfalse.s  IL_0077

      IL_006e:  ldarg      0
      IL_0072:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0077:  endfinally
    }  // end handler
    IL_0078:  ret
  } // end of method INetworkEvents_EventProvider::add_NetworkPropertyChanged

  .method public virtual instance void  remove_NetworkPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler A_1) cil managed
  {
    // Code size       246 (0xf6)
    .maxstack  6
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_3
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0014:  brfalse    IL_00e3

      IL_0019:  ldarg      0
      IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4     0x0
      IL_002d:  stloc.1
      IL_002e:  ldc.i4     0x0
      IL_0033:  ldloc.0
      IL_0034:  bge        IL_00e3

      IL_0039:  ldarg      0
      IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0042:  ldloc.1
      IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
      IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper
      IL_004d:  stloc.2
      IL_004e:  ldloc.2
      IL_004f:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkPropertyChangedDelegate
      IL_0054:  ldnull
      IL_0055:  beq        IL_00d4

      IL_005a:  ldloc.2
      IL_005b:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkEvents_NetworkPropertyChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_NetworkPropertyChangedDelegate
      IL_0060:  ldarg      A_1
      IL_0064:  castclass  [mscorlib]System.Object
      IL_0069:  callvirt   instance bool [mscorlib]System.Delegate::Equals(object)
      IL_006e:  ldc.i4     0xff
      IL_0073:  and
      IL_0074:  ldc.i4     0x0
      IL_0079:  beq        IL_00d4

      IL_007e:  ldarg      0
      IL_0082:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_0087:  ldloc.1
      IL_0088:  callvirt   instance void [mscorlib]System.Collections.ArrayList::RemoveAt(int32)
      IL_008d:  ldarg      0
      IL_0091:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_0096:  ldloc.2
      IL_0097:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_dwCookie
      IL_009c:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
      IL_00a1:  ldloc.0
      IL_00a2:  ldc.i4     0x1
      IL_00a7:  bgt        IL_00e3

      IL_00ac:  ldarg      0
      IL_00b0:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_00b5:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
      IL_00ba:  pop
      IL_00bb:  ldarg      0
      IL_00bf:  ldnull
      IL_00c0:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
      IL_00c5:  ldarg      0
      IL_00c9:  ldnull
      IL_00ca:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
      IL_00cf:  br         IL_00e3

      IL_00d4:  ldloc.1
      IL_00d5:  ldc.i4     0x1
      IL_00da:  add
      IL_00db:  stloc.1
      IL_00dc:  ldloc.1
      IL_00dd:  ldloc.0
      IL_00de:  blt        IL_0039

      IL_00e3:  leave      IL_00f5

    }  // end .try
    finally
    {
      IL_00e8:  ldloc.3
      IL_00e9:  brfalse.s  IL_00f4

      IL_00eb:  ldarg      0
      IL_00ef:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00f4:  endfinally
    }  // end handler
    IL_00f5:  ret
  } // end of method INetworkEvents_EventProvider::remove_NetworkPropertyChanged

  .method public specialname rtspecialname 
          instance void  .ctor(object A_1) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  6
    IL_0000:  ldarg      0
    IL_0004:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0009:  ldarg      0
    IL_000d:  ldarg      A_1
    IL_0011:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer
    IL_0016:  ldc.i4.0
    IL_0017:  newobj     instance void [mscorlib]System.WeakReference::.ctor(object,
                                                                             bool)
    IL_001c:  stfld      class [mscorlib]System.WeakReference Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_wkConnectionPointContainer
    IL_0021:  ret
  } // end of method INetworkEvents_EventProvider::.ctor

  .method public virtual instance void  Finalize() cil managed
  {
    // Code size       158 (0x9e)
    .maxstack  5
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      .try
      {
        IL_0000:  ldarg      0
        IL_0004:  ldloca.s   V_3
        IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                            bool&)
        IL_000b:  ldarg      0
        IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
        IL_0014:  brfalse    IL_0080

        IL_0019:  ldarg      0
        IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
        IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
        IL_0027:  stloc.0
        IL_0028:  ldc.i4     0x0
        IL_002d:  stloc.1
        IL_002e:  ldc.i4     0x0
        IL_0033:  ldloc.0
        IL_0034:  bge        IL_0071

        IL_0039:  ldarg      0
        IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_aEventSinkHelpers
        IL_0042:  ldloc.1
        IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
        IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper
        IL_004d:  stloc.2
        IL_004e:  ldarg      0
        IL_0052:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
        IL_0057:  ldloc.2
        IL_0058:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkEvents_SinkHelper::m_dwCookie
        IL_005d:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
        IL_0062:  ldloc.1
        IL_0063:  ldc.i4     0x1
        IL_0068:  add
        IL_0069:  stloc.1
        IL_006a:  ldloc.1
        IL_006b:  ldloc.0
        IL_006c:  blt        IL_0039

        IL_0071:  ldarg      0
        IL_0075:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::m_ConnectionPoint
        IL_007a:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
        IL_007f:  pop
        IL_0080:  leave      IL_008b

      }  // end .try
      catch [mscorlib]System.Exception 
      {
        IL_0085:  pop
        IL_0086:  leave      IL_008b

      }  // end handler
      IL_008b:  leave      IL_009d

    }  // end .try
    finally
    {
      IL_0090:  ldloc.3
      IL_0091:  brfalse.s  IL_009c

      IL_0093:  ldarg      0
      IL_0097:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_009c:  endfinally
    }  // end handler
    IL_009d:  ret
  } // end of method INetworkEvents_EventProvider::Finalize

  .method public virtual instance void  Dispose() cil managed
  {
    // Code size       19 (0x13)
    .maxstack  2
    IL_0000:  ldarg      0
    IL_0004:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider::Finalize()
    IL_0009:  ldarg      0
    IL_000d:  call       void [mscorlib]System.GC::SuppressFinalize(object)
    IL_0012:  ret
  } // end of method INetworkEvents_EventProvider::Dispose

} // end of class Vanara.PInvoke.NetListMgr.INetworkEvents_EventProvider

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper
       extends [mscorlib]System.Object
       implements Vanara.PInvoke.NetListMgr.INetworkConnectionEvents
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ClassInterfaceType) = ( 01 00 00 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .field public class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler m_NetworkConnectionConnectivityChangedDelegate
  .field public class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler m_NetworkConnectionPropertyChangedDelegate
  .field public int32 m_dwCookie
  .method public virtual instance void  NetworkConnectionConnectivityChanged(valuetype [mscorlib]System.Guid A_1,
                                                                             valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY A_2) cil managed
  {
    // Code size       38 (0x26)
    .maxstack  3
    IL_0000:  ldarg      0
    IL_0004:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_NetworkConnectionConnectivityChangedDelegate
    IL_0009:  brfalse    IL_0025

    IL_000e:  ldarg      0
    IL_0012:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_NetworkConnectionConnectivityChangedDelegate
    IL_0017:  ldarg      A_1
    IL_001b:  ldarg      A_2
    IL_001f:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler::Invoke(valuetype [mscorlib]System.Guid,
                                                                                                                                                   valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY)
    IL_0024:  ret

    IL_0025:  ret
  } // end of method INetworkConnectionEvents_SinkHelper::NetworkConnectionConnectivityChanged

  .method public virtual instance void  NetworkConnectionPropertyChanged(valuetype [mscorlib]System.Guid A_1,
                                                                         valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_PROPERTY_CHANGE A_2) cil managed
  {
    // Code size       38 (0x26)
    .maxstack  3
    IL_0000:  ldarg      0
    IL_0004:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_NetworkConnectionPropertyChangedDelegate
    IL_0009:  brfalse    IL_0025

    IL_000e:  ldarg      0
    IL_0012:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_NetworkConnectionPropertyChangedDelegate
    IL_0017:  ldarg      A_1
    IL_001b:  ldarg      A_2
    IL_001f:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler::Invoke(valuetype [mscorlib]System.Guid,
                                                                                                                                               valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_PROPERTY_CHANGE)
    IL_0024:  ret

    IL_0025:  ret
  } // end of method INetworkConnectionEvents_SinkHelper::NetworkConnectionPropertyChanged

  .method assembly specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       44 (0x2c)
    .maxstack  4
    IL_0000:  ldarg      0
    IL_0004:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0009:  ldarg      0
    IL_000d:  ldc.i4     0x0
    IL_0012:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_dwCookie
    IL_0017:  ldarg      0
    IL_001b:  ldnull
    IL_001c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_NetworkConnectionConnectivityChangedDelegate
    IL_0021:  ldarg      0
    IL_0025:  ldnull
    IL_0026:  stfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_NetworkConnectionPropertyChangedDelegate
    IL_002b:  ret
  } // end of method INetworkConnectionEvents_SinkHelper::.ctor

} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper

.class private auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider
       extends [mscorlib]System.Object
       implements Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_Event,
                  [mscorlib]System.IDisposable
{
  .field private class [mscorlib]System.WeakReference m_wkConnectionPointContainer
  .field private class [mscorlib]System.Collections.ArrayList m_aEventSinkHelpers
  .field private class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint m_ConnectionPoint
  .method private instance void  Init() cil managed
  {
    // Code size       271 (0x10f)
    .maxstack  5
    .locals init (class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint V_0,
             valuetype [mscorlib]System.Guid V_1,
             uint8[] V_2)
    IL_0000:  ldnull
    IL_0001:  stloc.0
    IL_0002:  ldc.i4     0x10
    IL_0007:  newarr     [mscorlib]System.Byte
    IL_000c:  stloc.2
    IL_000d:  ldloc.2
    IL_000e:  ldc.i4     0x0
    IL_0013:  ldc.i4     0x7
    IL_0018:  stelem.i1
    IL_0019:  ldloc.2
    IL_001a:  ldc.i4     0x1
    IL_001f:  ldc.i4     0x0
    IL_0024:  stelem.i1
    IL_0025:  ldloc.2
    IL_0026:  ldc.i4     0x2
    IL_002b:  ldc.i4     0xb0
    IL_0030:  stelem.i1
    IL_0031:  ldloc.2
    IL_0032:  ldc.i4     0x3
    IL_0037:  ldc.i4     0xdc
    IL_003c:  stelem.i1
    IL_003d:  ldloc.2
    IL_003e:  ldc.i4     0x4
    IL_0043:  ldc.i4     0xf
    IL_0048:  stelem.i1
    IL_0049:  ldloc.2
    IL_004a:  ldc.i4     0x5
    IL_004f:  ldc.i4     0x57
    IL_0054:  stelem.i1
    IL_0055:  ldloc.2
    IL_0056:  ldc.i4     0x6
    IL_005b:  ldc.i4     0x9b
    IL_0060:  stelem.i1
    IL_0061:  ldloc.2
    IL_0062:  ldc.i4     0x7
    IL_0067:  ldc.i4     0x4a
    IL_006c:  stelem.i1
    IL_006d:  ldloc.2
    IL_006e:  ldc.i4     0x8
    IL_0073:  ldc.i4     0x8d
    IL_0078:  stelem.i1
    IL_0079:  ldloc.2
    IL_007a:  ldc.i4     0x9
    IL_007f:  ldc.i4     0x69
    IL_0084:  stelem.i1
    IL_0085:  ldloc.2
    IL_0086:  ldc.i4     0xa
    IL_008b:  ldc.i4     0x19
    IL_0090:  stelem.i1
    IL_0091:  ldloc.2
    IL_0092:  ldc.i4     0xb
    IL_0097:  ldc.i4     0x9f
    IL_009c:  stelem.i1
    IL_009d:  ldloc.2
    IL_009e:  ldc.i4     0xc
    IL_00a3:  ldc.i4     0xdb
    IL_00a8:  stelem.i1
    IL_00a9:  ldloc.2
    IL_00aa:  ldc.i4     0xd
    IL_00af:  ldc.i4     0xa5
    IL_00b4:  stelem.i1
    IL_00b5:  ldloc.2
    IL_00b6:  ldc.i4     0xe
    IL_00bb:  ldc.i4     0x72
    IL_00c0:  stelem.i1
    IL_00c1:  ldloc.2
    IL_00c2:  ldc.i4     0xf
    IL_00c7:  ldc.i4     0x3b
    IL_00cc:  stelem.i1
    IL_00cd:  ldloca.s   V_1
    IL_00cf:  ldloc.2
    IL_00d0:  call       instance void [mscorlib]System.Guid::.ctor(uint8[])
    IL_00d5:  ldarg      0
    IL_00d9:  ldfld      class [mscorlib]System.WeakReference Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_wkConnectionPointContainer
    IL_00de:  callvirt   instance object [mscorlib]System.WeakReference::get_Target()
    IL_00e3:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer
    IL_00e8:  ldloca.s   V_1
    IL_00ea:  ldloca.s   V_0
    IL_00ec:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer::FindConnectionPoint(valuetype [mscorlib]System.Guid&,
                                                                                                                                        class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint&)
    IL_00f1:  ldarg      0
    IL_00f5:  ldloc.0
    IL_00f6:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint
    IL_00fb:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
    IL_0100:  ldarg      0
    IL_0104:  newobj     instance void [mscorlib]System.Collections.ArrayList::.ctor()
    IL_0109:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
    IL_010e:  ret
  } // end of method INetworkConnectionEvents_EventProvider::Init

  .method public virtual instance void  add_NetworkConnectionConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler A_1) cil managed
  {
    // Code size       121 (0x79)
    .maxstack  6
    .locals init (class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper V_0,
             int32 V_1,
             bool V_2)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_2
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
      IL_0014:  brtrue     IL_0022

      IL_0019:  ldarg      0
      IL_001d:  call       instance void Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::Init()
      IL_0022:  newobj     instance void Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::.ctor()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4.0
      IL_0029:  stloc.1
      IL_002a:  ldarg      0
      IL_002e:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
      IL_0033:  ldloc.0
      IL_0034:  castclass  [mscorlib]System.Object
      IL_0039:  ldloca.s   V_1
      IL_003b:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Advise(object,
                                                                                                                    int32&)
      IL_0040:  ldloc.0
      IL_0041:  ldloc.1
      IL_0042:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_dwCookie
      IL_0047:  ldloc.0
      IL_0048:  ldarg      A_1
      IL_004c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_NetworkConnectionConnectivityChangedDelegate
      IL_0051:  ldarg      0
      IL_0055:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
      IL_005a:  ldloc.0
      IL_005b:  castclass  [mscorlib]System.Object
      IL_0060:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::Add(object)
      IL_0065:  pop
      IL_0066:  leave      IL_0078

    }  // end .try
    finally
    {
      IL_006b:  ldloc.2
      IL_006c:  brfalse.s  IL_0077

      IL_006e:  ldarg      0
      IL_0072:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0077:  endfinally
    }  // end handler
    IL_0078:  ret
  } // end of method INetworkConnectionEvents_EventProvider::add_NetworkConnectionConnectivityChanged

  .method public virtual instance void  remove_NetworkConnectionConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler A_1) cil managed
  {
    // Code size       246 (0xf6)
    .maxstack  6
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_3
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
      IL_0014:  brfalse    IL_00e3

      IL_0019:  ldarg      0
      IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
      IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4     0x0
      IL_002d:  stloc.1
      IL_002e:  ldc.i4     0x0
      IL_0033:  ldloc.0
      IL_0034:  bge        IL_00e3

      IL_0039:  ldarg      0
      IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
      IL_0042:  ldloc.1
      IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
      IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper
      IL_004d:  stloc.2
      IL_004e:  ldloc.2
      IL_004f:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_NetworkConnectionConnectivityChangedDelegate
      IL_0054:  ldnull
      IL_0055:  beq        IL_00d4

      IL_005a:  ldloc.2
      IL_005b:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_NetworkConnectionConnectivityChangedDelegate
      IL_0060:  ldarg      A_1
      IL_0064:  castclass  [mscorlib]System.Object
      IL_0069:  callvirt   instance bool [mscorlib]System.Delegate::Equals(object)
      IL_006e:  ldc.i4     0xff
      IL_0073:  and
      IL_0074:  ldc.i4     0x0
      IL_0079:  beq        IL_00d4

      IL_007e:  ldarg      0
      IL_0082:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
      IL_0087:  ldloc.1
      IL_0088:  callvirt   instance void [mscorlib]System.Collections.ArrayList::RemoveAt(int32)
      IL_008d:  ldarg      0
      IL_0091:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
      IL_0096:  ldloc.2
      IL_0097:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_dwCookie
      IL_009c:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
      IL_00a1:  ldloc.0
      IL_00a2:  ldc.i4     0x1
      IL_00a7:  bgt        IL_00e3

      IL_00ac:  ldarg      0
      IL_00b0:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
      IL_00b5:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
      IL_00ba:  pop
      IL_00bb:  ldarg      0
      IL_00bf:  ldnull
      IL_00c0:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
      IL_00c5:  ldarg      0
      IL_00c9:  ldnull
      IL_00ca:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
      IL_00cf:  br         IL_00e3

      IL_00d4:  ldloc.1
      IL_00d5:  ldc.i4     0x1
      IL_00da:  add
      IL_00db:  stloc.1
      IL_00dc:  ldloc.1
      IL_00dd:  ldloc.0
      IL_00de:  blt        IL_0039

      IL_00e3:  leave      IL_00f5

    }  // end .try
    finally
    {
      IL_00e8:  ldloc.3
      IL_00e9:  brfalse.s  IL_00f4

      IL_00eb:  ldarg      0
      IL_00ef:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00f4:  endfinally
    }  // end handler
    IL_00f5:  ret
  } // end of method INetworkConnectionEvents_EventProvider::remove_NetworkConnectionConnectivityChanged

  .method public virtual instance void  add_NetworkConnectionPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler A_1) cil managed
  {
    // Code size       121 (0x79)
    .maxstack  6
    .locals init (class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper V_0,
             int32 V_1,
             bool V_2)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_2
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
      IL_0014:  brtrue     IL_0022

      IL_0019:  ldarg      0
      IL_001d:  call       instance void Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::Init()
      IL_0022:  newobj     instance void Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::.ctor()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4.0
      IL_0029:  stloc.1
      IL_002a:  ldarg      0
      IL_002e:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
      IL_0033:  ldloc.0
      IL_0034:  castclass  [mscorlib]System.Object
      IL_0039:  ldloca.s   V_1
      IL_003b:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Advise(object,
                                                                                                                    int32&)
      IL_0040:  ldloc.0
      IL_0041:  ldloc.1
      IL_0042:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_dwCookie
      IL_0047:  ldloc.0
      IL_0048:  ldarg      A_1
      IL_004c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_NetworkConnectionPropertyChangedDelegate
      IL_0051:  ldarg      0
      IL_0055:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
      IL_005a:  ldloc.0
      IL_005b:  castclass  [mscorlib]System.Object
      IL_0060:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::Add(object)
      IL_0065:  pop
      IL_0066:  leave      IL_0078

    }  // end .try
    finally
    {
      IL_006b:  ldloc.2
      IL_006c:  brfalse.s  IL_0077

      IL_006e:  ldarg      0
      IL_0072:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0077:  endfinally
    }  // end handler
    IL_0078:  ret
  } // end of method INetworkConnectionEvents_EventProvider::add_NetworkConnectionPropertyChanged

  .method public virtual instance void  remove_NetworkConnectionPropertyChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler A_1) cil managed
  {
    // Code size       246 (0xf6)
    .maxstack  6
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_3
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
      IL_0014:  brfalse    IL_00e3

      IL_0019:  ldarg      0
      IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
      IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4     0x0
      IL_002d:  stloc.1
      IL_002e:  ldc.i4     0x0
      IL_0033:  ldloc.0
      IL_0034:  bge        IL_00e3

      IL_0039:  ldarg      0
      IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
      IL_0042:  ldloc.1
      IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
      IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper
      IL_004d:  stloc.2
      IL_004e:  ldloc.2
      IL_004f:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_NetworkConnectionPropertyChangedDelegate
      IL_0054:  ldnull
      IL_0055:  beq        IL_00d4

      IL_005a:  ldloc.2
      IL_005b:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_NetworkConnectionPropertyChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_NetworkConnectionPropertyChangedDelegate
      IL_0060:  ldarg      A_1
      IL_0064:  castclass  [mscorlib]System.Object
      IL_0069:  callvirt   instance bool [mscorlib]System.Delegate::Equals(object)
      IL_006e:  ldc.i4     0xff
      IL_0073:  and
      IL_0074:  ldc.i4     0x0
      IL_0079:  beq        IL_00d4

      IL_007e:  ldarg      0
      IL_0082:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
      IL_0087:  ldloc.1
      IL_0088:  callvirt   instance void [mscorlib]System.Collections.ArrayList::RemoveAt(int32)
      IL_008d:  ldarg      0
      IL_0091:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
      IL_0096:  ldloc.2
      IL_0097:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_dwCookie
      IL_009c:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
      IL_00a1:  ldloc.0
      IL_00a2:  ldc.i4     0x1
      IL_00a7:  bgt        IL_00e3

      IL_00ac:  ldarg      0
      IL_00b0:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
      IL_00b5:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
      IL_00ba:  pop
      IL_00bb:  ldarg      0
      IL_00bf:  ldnull
      IL_00c0:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
      IL_00c5:  ldarg      0
      IL_00c9:  ldnull
      IL_00ca:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
      IL_00cf:  br         IL_00e3

      IL_00d4:  ldloc.1
      IL_00d5:  ldc.i4     0x1
      IL_00da:  add
      IL_00db:  stloc.1
      IL_00dc:  ldloc.1
      IL_00dd:  ldloc.0
      IL_00de:  blt        IL_0039

      IL_00e3:  leave      IL_00f5

    }  // end .try
    finally
    {
      IL_00e8:  ldloc.3
      IL_00e9:  brfalse.s  IL_00f4

      IL_00eb:  ldarg      0
      IL_00ef:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00f4:  endfinally
    }  // end handler
    IL_00f5:  ret
  } // end of method INetworkConnectionEvents_EventProvider::remove_NetworkConnectionPropertyChanged

  .method public specialname rtspecialname 
          instance void  .ctor(object A_1) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  6
    IL_0000:  ldarg      0
    IL_0004:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0009:  ldarg      0
    IL_000d:  ldarg      A_1
    IL_0011:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer
    IL_0016:  ldc.i4.0
    IL_0017:  newobj     instance void [mscorlib]System.WeakReference::.ctor(object,
                                                                             bool)
    IL_001c:  stfld      class [mscorlib]System.WeakReference Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_wkConnectionPointContainer
    IL_0021:  ret
  } // end of method INetworkConnectionEvents_EventProvider::.ctor

  .method public virtual instance void  Finalize() cil managed
  {
    // Code size       158 (0x9e)
    .maxstack  5
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      .try
      {
        IL_0000:  ldarg      0
        IL_0004:  ldloca.s   V_3
        IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                            bool&)
        IL_000b:  ldarg      0
        IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
        IL_0014:  brfalse    IL_0080

        IL_0019:  ldarg      0
        IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
        IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
        IL_0027:  stloc.0
        IL_0028:  ldc.i4     0x0
        IL_002d:  stloc.1
        IL_002e:  ldc.i4     0x0
        IL_0033:  ldloc.0
        IL_0034:  bge        IL_0071

        IL_0039:  ldarg      0
        IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_aEventSinkHelpers
        IL_0042:  ldloc.1
        IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
        IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper
        IL_004d:  stloc.2
        IL_004e:  ldarg      0
        IL_0052:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
        IL_0057:  ldloc.2
        IL_0058:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_SinkHelper::m_dwCookie
        IL_005d:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
        IL_0062:  ldloc.1
        IL_0063:  ldc.i4     0x1
        IL_0068:  add
        IL_0069:  stloc.1
        IL_006a:  ldloc.1
        IL_006b:  ldloc.0
        IL_006c:  blt        IL_0039

        IL_0071:  ldarg      0
        IL_0075:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::m_ConnectionPoint
        IL_007a:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
        IL_007f:  pop
        IL_0080:  leave      IL_008b

      }  // end .try
      catch [mscorlib]System.Exception 
      {
        IL_0085:  pop
        IL_0086:  leave      IL_008b

      }  // end handler
      IL_008b:  leave      IL_009d

    }  // end .try
    finally
    {
      IL_0090:  ldloc.3
      IL_0091:  brfalse.s  IL_009c

      IL_0093:  ldarg      0
      IL_0097:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_009c:  endfinally
    }  // end handler
    IL_009d:  ret
  } // end of method INetworkConnectionEvents_EventProvider::Finalize

  .method public virtual instance void  Dispose() cil managed
  {
    // Code size       19 (0x13)
    .maxstack  2
    IL_0000:  ldarg      0
    IL_0004:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider::Finalize()
    IL_0009:  ldarg      0
    IL_000d:  call       void [mscorlib]System.GC::SuppressFinalize(object)
    IL_0012:  ret
  } // end of method INetworkConnectionEvents_EventProvider::Dispose

} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionEvents_EventProvider

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper
       extends [mscorlib]System.Object
       implements Vanara.PInvoke.NetListMgr.INetworkListManagerEvents
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ClassInterfaceType) = ( 01 00 00 00 00 00 00 00 ) 
  .field public class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler m_ConnectivityChangedDelegate
  .field public int32 m_dwCookie
  .method public virtual instance void  ConnectivityChanged(valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY A_1) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  2
    IL_0000:  ldarg      0
    IL_0004:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper::m_ConnectivityChangedDelegate
    IL_0009:  brfalse    IL_0021

    IL_000e:  ldarg      0
    IL_0012:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper::m_ConnectivityChangedDelegate
    IL_0017:  ldarg      A_1
    IL_001b:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler::Invoke(valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTIVITY)
    IL_0020:  ret

    IL_0021:  ret
  } // end of method INetworkListManagerEvents_SinkHelper::ConnectivityChanged

  .method assembly specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       34 (0x22)
    .maxstack  4
    IL_0000:  ldarg      0
    IL_0004:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0009:  ldarg      0
    IL_000d:  ldc.i4     0x0
    IL_0012:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper::m_dwCookie
    IL_0017:  ldarg      0
    IL_001b:  ldnull
    IL_001c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper::m_ConnectivityChangedDelegate
    IL_0021:  ret
  } // end of method INetworkListManagerEvents_SinkHelper::.ctor

} // end of class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper

.class private auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider
       extends [mscorlib]System.Object
       implements Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_Event,
                  [mscorlib]System.IDisposable
{
  .field private class [mscorlib]System.WeakReference m_wkConnectionPointContainer
  .field private class [mscorlib]System.Collections.ArrayList m_aEventSinkHelpers
  .field private class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint m_ConnectionPoint
  .method private instance void  Init() cil managed
  {
    // Code size       271 (0x10f)
    .maxstack  5
    .locals init (class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint V_0,
             valuetype [mscorlib]System.Guid V_1,
             uint8[] V_2)
    IL_0000:  ldnull
    IL_0001:  stloc.0
    IL_0002:  ldc.i4     0x10
    IL_0007:  newarr     [mscorlib]System.Byte
    IL_000c:  stloc.2
    IL_000d:  ldloc.2
    IL_000e:  ldc.i4     0x0
    IL_0013:  ldc.i4     0x1
    IL_0018:  stelem.i1
    IL_0019:  ldloc.2
    IL_001a:  ldc.i4     0x1
    IL_001f:  ldc.i4     0x0
    IL_0024:  stelem.i1
    IL_0025:  ldloc.2
    IL_0026:  ldc.i4     0x2
    IL_002b:  ldc.i4     0xb0
    IL_0030:  stelem.i1
    IL_0031:  ldloc.2
    IL_0032:  ldc.i4     0x3
    IL_0037:  ldc.i4     0xdc
    IL_003c:  stelem.i1
    IL_003d:  ldloc.2
    IL_003e:  ldc.i4     0x4
    IL_0043:  ldc.i4     0xf
    IL_0048:  stelem.i1
    IL_0049:  ldloc.2
    IL_004a:  ldc.i4     0x5
    IL_004f:  ldc.i4     0x57
    IL_0054:  stelem.i1
    IL_0055:  ldloc.2
    IL_0056:  ldc.i4     0x6
    IL_005b:  ldc.i4     0x9b
    IL_0060:  stelem.i1
    IL_0061:  ldloc.2
    IL_0062:  ldc.i4     0x7
    IL_0067:  ldc.i4     0x4a
    IL_006c:  stelem.i1
    IL_006d:  ldloc.2
    IL_006e:  ldc.i4     0x8
    IL_0073:  ldc.i4     0x8d
    IL_0078:  stelem.i1
    IL_0079:  ldloc.2
    IL_007a:  ldc.i4     0x9
    IL_007f:  ldc.i4     0x69
    IL_0084:  stelem.i1
    IL_0085:  ldloc.2
    IL_0086:  ldc.i4     0xa
    IL_008b:  ldc.i4     0x19
    IL_0090:  stelem.i1
    IL_0091:  ldloc.2
    IL_0092:  ldc.i4     0xb
    IL_0097:  ldc.i4     0x9f
    IL_009c:  stelem.i1
    IL_009d:  ldloc.2
    IL_009e:  ldc.i4     0xc
    IL_00a3:  ldc.i4     0xdb
    IL_00a8:  stelem.i1
    IL_00a9:  ldloc.2
    IL_00aa:  ldc.i4     0xd
    IL_00af:  ldc.i4     0xa5
    IL_00b4:  stelem.i1
    IL_00b5:  ldloc.2
    IL_00b6:  ldc.i4     0xe
    IL_00bb:  ldc.i4     0x72
    IL_00c0:  stelem.i1
    IL_00c1:  ldloc.2
    IL_00c2:  ldc.i4     0xf
    IL_00c7:  ldc.i4     0x3b
    IL_00cc:  stelem.i1
    IL_00cd:  ldloca.s   V_1
    IL_00cf:  ldloc.2
    IL_00d0:  call       instance void [mscorlib]System.Guid::.ctor(uint8[])
    IL_00d5:  ldarg      0
    IL_00d9:  ldfld      class [mscorlib]System.WeakReference Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_wkConnectionPointContainer
    IL_00de:  callvirt   instance object [mscorlib]System.WeakReference::get_Target()
    IL_00e3:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer
    IL_00e8:  ldloca.s   V_1
    IL_00ea:  ldloca.s   V_0
    IL_00ec:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer::FindConnectionPoint(valuetype [mscorlib]System.Guid&,
                                                                                                                                        class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint&)
    IL_00f1:  ldarg      0
    IL_00f5:  ldloc.0
    IL_00f6:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint
    IL_00fb:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_ConnectionPoint
    IL_0100:  ldarg      0
    IL_0104:  newobj     instance void [mscorlib]System.Collections.ArrayList::.ctor()
    IL_0109:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_aEventSinkHelpers
    IL_010e:  ret
  } // end of method INetworkListManagerEvents_EventProvider::Init

  .method public virtual instance void  add_ConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler A_1) cil managed
  {
    // Code size       121 (0x79)
    .maxstack  6
    .locals init (class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper V_0,
             int32 V_1,
             bool V_2)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_2
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_ConnectionPoint
      IL_0014:  brtrue     IL_0022

      IL_0019:  ldarg      0
      IL_001d:  call       instance void Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::Init()
      IL_0022:  newobj     instance void Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper::.ctor()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4.0
      IL_0029:  stloc.1
      IL_002a:  ldarg      0
      IL_002e:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_ConnectionPoint
      IL_0033:  ldloc.0
      IL_0034:  castclass  [mscorlib]System.Object
      IL_0039:  ldloca.s   V_1
      IL_003b:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Advise(object,
                                                                                                                    int32&)
      IL_0040:  ldloc.0
      IL_0041:  ldloc.1
      IL_0042:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper::m_dwCookie
      IL_0047:  ldloc.0
      IL_0048:  ldarg      A_1
      IL_004c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper::m_ConnectivityChangedDelegate
      IL_0051:  ldarg      0
      IL_0055:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_005a:  ldloc.0
      IL_005b:  castclass  [mscorlib]System.Object
      IL_0060:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::Add(object)
      IL_0065:  pop
      IL_0066:  leave      IL_0078

    }  // end .try
    finally
    {
      IL_006b:  ldloc.2
      IL_006c:  brfalse.s  IL_0077

      IL_006e:  ldarg      0
      IL_0072:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0077:  endfinally
    }  // end handler
    IL_0078:  ret
  } // end of method INetworkListManagerEvents_EventProvider::add_ConnectivityChanged

  .method public virtual instance void  remove_ConnectivityChanged(class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler A_1) cil managed
  {
    // Code size       246 (0xf6)
    .maxstack  6
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_3
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_0014:  brfalse    IL_00e3

      IL_0019:  ldarg      0
      IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4     0x0
      IL_002d:  stloc.1
      IL_002e:  ldc.i4     0x0
      IL_0033:  ldloc.0
      IL_0034:  bge        IL_00e3

      IL_0039:  ldarg      0
      IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_0042:  ldloc.1
      IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
      IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper
      IL_004d:  stloc.2
      IL_004e:  ldloc.2
      IL_004f:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper::m_ConnectivityChangedDelegate
      IL_0054:  ldnull
      IL_0055:  beq        IL_00d4

      IL_005a:  ldloc.2
      IL_005b:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_ConnectivityChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper::m_ConnectivityChangedDelegate
      IL_0060:  ldarg      A_1
      IL_0064:  castclass  [mscorlib]System.Object
      IL_0069:  callvirt   instance bool [mscorlib]System.Delegate::Equals(object)
      IL_006e:  ldc.i4     0xff
      IL_0073:  and
      IL_0074:  ldc.i4     0x0
      IL_0079:  beq        IL_00d4

      IL_007e:  ldarg      0
      IL_0082:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_0087:  ldloc.1
      IL_0088:  callvirt   instance void [mscorlib]System.Collections.ArrayList::RemoveAt(int32)
      IL_008d:  ldarg      0
      IL_0091:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_ConnectionPoint
      IL_0096:  ldloc.2
      IL_0097:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper::m_dwCookie
      IL_009c:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
      IL_00a1:  ldloc.0
      IL_00a2:  ldc.i4     0x1
      IL_00a7:  bgt        IL_00e3

      IL_00ac:  ldarg      0
      IL_00b0:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_ConnectionPoint
      IL_00b5:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
      IL_00ba:  pop
      IL_00bb:  ldarg      0
      IL_00bf:  ldnull
      IL_00c0:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_ConnectionPoint
      IL_00c5:  ldarg      0
      IL_00c9:  ldnull
      IL_00ca:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_00cf:  br         IL_00e3

      IL_00d4:  ldloc.1
      IL_00d5:  ldc.i4     0x1
      IL_00da:  add
      IL_00db:  stloc.1
      IL_00dc:  ldloc.1
      IL_00dd:  ldloc.0
      IL_00de:  blt        IL_0039

      IL_00e3:  leave      IL_00f5

    }  // end .try
    finally
    {
      IL_00e8:  ldloc.3
      IL_00e9:  brfalse.s  IL_00f4

      IL_00eb:  ldarg      0
      IL_00ef:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00f4:  endfinally
    }  // end handler
    IL_00f5:  ret
  } // end of method INetworkListManagerEvents_EventProvider::remove_ConnectivityChanged

  .method public specialname rtspecialname 
          instance void  .ctor(object A_1) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  6
    IL_0000:  ldarg      0
    IL_0004:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0009:  ldarg      0
    IL_000d:  ldarg      A_1
    IL_0011:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer
    IL_0016:  ldc.i4.0
    IL_0017:  newobj     instance void [mscorlib]System.WeakReference::.ctor(object,
                                                                             bool)
    IL_001c:  stfld      class [mscorlib]System.WeakReference Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_wkConnectionPointContainer
    IL_0021:  ret
  } // end of method INetworkListManagerEvents_EventProvider::.ctor

  .method public virtual instance void  Finalize() cil managed
  {
    // Code size       158 (0x9e)
    .maxstack  5
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      .try
      {
        IL_0000:  ldarg      0
        IL_0004:  ldloca.s   V_3
        IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                            bool&)
        IL_000b:  ldarg      0
        IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_ConnectionPoint
        IL_0014:  brfalse    IL_0080

        IL_0019:  ldarg      0
        IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_aEventSinkHelpers
        IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
        IL_0027:  stloc.0
        IL_0028:  ldc.i4     0x0
        IL_002d:  stloc.1
        IL_002e:  ldc.i4     0x0
        IL_0033:  ldloc.0
        IL_0034:  bge        IL_0071

        IL_0039:  ldarg      0
        IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_aEventSinkHelpers
        IL_0042:  ldloc.1
        IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
        IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper
        IL_004d:  stloc.2
        IL_004e:  ldarg      0
        IL_0052:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_ConnectionPoint
        IL_0057:  ldloc.2
        IL_0058:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_SinkHelper::m_dwCookie
        IL_005d:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
        IL_0062:  ldloc.1
        IL_0063:  ldc.i4     0x1
        IL_0068:  add
        IL_0069:  stloc.1
        IL_006a:  ldloc.1
        IL_006b:  ldloc.0
        IL_006c:  blt        IL_0039

        IL_0071:  ldarg      0
        IL_0075:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::m_ConnectionPoint
        IL_007a:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
        IL_007f:  pop
        IL_0080:  leave      IL_008b

      }  // end .try
      catch [mscorlib]System.Exception 
      {
        IL_0085:  pop
        IL_0086:  leave      IL_008b

      }  // end handler
      IL_008b:  leave      IL_009d

    }  // end .try
    finally
    {
      IL_0090:  ldloc.3
      IL_0091:  brfalse.s  IL_009c

      IL_0093:  ldarg      0
      IL_0097:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_009c:  endfinally
    }  // end handler
    IL_009d:  ret
  } // end of method INetworkListManagerEvents_EventProvider::Finalize

  .method public virtual instance void  Dispose() cil managed
  {
    // Code size       19 (0x13)
    .maxstack  2
    IL_0000:  ldarg      0
    IL_0004:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider::Finalize()
    IL_0009:  ldarg      0
    IL_000d:  call       void [mscorlib]System.GC::SuppressFinalize(object)
    IL_0012:  ret
  } // end of method INetworkListManagerEvents_EventProvider::Dispose

} // end of class Vanara.PInvoke.NetListMgr.INetworkListManagerEvents_EventProvider

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper
       extends [mscorlib]System.Object
       implements Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ClassInterfaceType) = ( 01 00 00 00 00 00 00 00 ) 
  .field public class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler m_CostChangedDelegate
  .field public class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler m_DataPlanStatusChangedDelegate
  .field public int32 m_dwCookie
  .method public virtual instance void  CostChanged(valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST A_1,
                                                    valuetype Vanara.PInvoke.NetListMgr.NLM_SOCKADDR& A_2) cil managed
  {
    // Code size       38 (0x26)
    .maxstack  3
    IL_0000:  ldarg      0
    IL_0004:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_CostChangedDelegate
    IL_0009:  brfalse    IL_0025

    IL_000e:  ldarg      0
    IL_0012:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_CostChangedDelegate
    IL_0017:  ldarg      A_1
    IL_001b:  ldarg      A_2
    IL_001f:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler::Invoke(valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST,
                                                                                                                           valuetype Vanara.PInvoke.NetListMgr.NLM_SOCKADDR&)
    IL_0024:  ret

    IL_0025:  ret
  } // end of method INetworkCostManagerEvents_SinkHelper::CostChanged

  .method public virtual instance void  DataPlanStatusChanged(valuetype Vanara.PInvoke.NetListMgr.NLM_SOCKADDR& A_1) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  2
    IL_0000:  ldarg      0
    IL_0004:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_DataPlanStatusChangedDelegate
    IL_0009:  brfalse    IL_0021

    IL_000e:  ldarg      0
    IL_0012:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_DataPlanStatusChangedDelegate
    IL_0017:  ldarg      A_1
    IL_001b:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler::Invoke(valuetype Vanara.PInvoke.NetListMgr.NLM_SOCKADDR&)
    IL_0020:  ret

    IL_0021:  ret
  } // end of method INetworkCostManagerEvents_SinkHelper::DataPlanStatusChanged

  .method assembly specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       44 (0x2c)
    .maxstack  4
    IL_0000:  ldarg      0
    IL_0004:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0009:  ldarg      0
    IL_000d:  ldc.i4     0x0
    IL_0012:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_dwCookie
    IL_0017:  ldarg      0
    IL_001b:  ldnull
    IL_001c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_CostChangedDelegate
    IL_0021:  ldarg      0
    IL_0025:  ldnull
    IL_0026:  stfld      class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_DataPlanStatusChangedDelegate
    IL_002b:  ret
  } // end of method INetworkCostManagerEvents_SinkHelper::.ctor

} // end of class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper

.class private auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider
       extends [mscorlib]System.Object
       implements Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_Event,
                  [mscorlib]System.IDisposable
{
  .field private class [mscorlib]System.WeakReference m_wkConnectionPointContainer
  .field private class [mscorlib]System.Collections.ArrayList m_aEventSinkHelpers
  .field private class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint m_ConnectionPoint
  .method private instance void  Init() cil managed
  {
    // Code size       271 (0x10f)
    .maxstack  5
    .locals init (class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint V_0,
             valuetype [mscorlib]System.Guid V_1,
             uint8[] V_2)
    IL_0000:  ldnull
    IL_0001:  stloc.0
    IL_0002:  ldc.i4     0x10
    IL_0007:  newarr     [mscorlib]System.Byte
    IL_000c:  stloc.2
    IL_000d:  ldloc.2
    IL_000e:  ldc.i4     0x0
    IL_0013:  ldc.i4     0x9
    IL_0018:  stelem.i1
    IL_0019:  ldloc.2
    IL_001a:  ldc.i4     0x1
    IL_001f:  ldc.i4     0x0
    IL_0024:  stelem.i1
    IL_0025:  ldloc.2
    IL_0026:  ldc.i4     0x2
    IL_002b:  ldc.i4     0xb0
    IL_0030:  stelem.i1
    IL_0031:  ldloc.2
    IL_0032:  ldc.i4     0x3
    IL_0037:  ldc.i4     0xdc
    IL_003c:  stelem.i1
    IL_003d:  ldloc.2
    IL_003e:  ldc.i4     0x4
    IL_0043:  ldc.i4     0xf
    IL_0048:  stelem.i1
    IL_0049:  ldloc.2
    IL_004a:  ldc.i4     0x5
    IL_004f:  ldc.i4     0x57
    IL_0054:  stelem.i1
    IL_0055:  ldloc.2
    IL_0056:  ldc.i4     0x6
    IL_005b:  ldc.i4     0x9b
    IL_0060:  stelem.i1
    IL_0061:  ldloc.2
    IL_0062:  ldc.i4     0x7
    IL_0067:  ldc.i4     0x4a
    IL_006c:  stelem.i1
    IL_006d:  ldloc.2
    IL_006e:  ldc.i4     0x8
    IL_0073:  ldc.i4     0x8d
    IL_0078:  stelem.i1
    IL_0079:  ldloc.2
    IL_007a:  ldc.i4     0x9
    IL_007f:  ldc.i4     0x69
    IL_0084:  stelem.i1
    IL_0085:  ldloc.2
    IL_0086:  ldc.i4     0xa
    IL_008b:  ldc.i4     0x19
    IL_0090:  stelem.i1
    IL_0091:  ldloc.2
    IL_0092:  ldc.i4     0xb
    IL_0097:  ldc.i4     0x9f
    IL_009c:  stelem.i1
    IL_009d:  ldloc.2
    IL_009e:  ldc.i4     0xc
    IL_00a3:  ldc.i4     0xdb
    IL_00a8:  stelem.i1
    IL_00a9:  ldloc.2
    IL_00aa:  ldc.i4     0xd
    IL_00af:  ldc.i4     0xa5
    IL_00b4:  stelem.i1
    IL_00b5:  ldloc.2
    IL_00b6:  ldc.i4     0xe
    IL_00bb:  ldc.i4     0x72
    IL_00c0:  stelem.i1
    IL_00c1:  ldloc.2
    IL_00c2:  ldc.i4     0xf
    IL_00c7:  ldc.i4     0x3b
    IL_00cc:  stelem.i1
    IL_00cd:  ldloca.s   V_1
    IL_00cf:  ldloc.2
    IL_00d0:  call       instance void [mscorlib]System.Guid::.ctor(uint8[])
    IL_00d5:  ldarg      0
    IL_00d9:  ldfld      class [mscorlib]System.WeakReference Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_wkConnectionPointContainer
    IL_00de:  callvirt   instance object [mscorlib]System.WeakReference::get_Target()
    IL_00e3:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer
    IL_00e8:  ldloca.s   V_1
    IL_00ea:  ldloca.s   V_0
    IL_00ec:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer::FindConnectionPoint(valuetype [mscorlib]System.Guid&,
                                                                                                                                        class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint&)
    IL_00f1:  ldarg      0
    IL_00f5:  ldloc.0
    IL_00f6:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint
    IL_00fb:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
    IL_0100:  ldarg      0
    IL_0104:  newobj     instance void [mscorlib]System.Collections.ArrayList::.ctor()
    IL_0109:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
    IL_010e:  ret
  } // end of method INetworkCostManagerEvents_EventProvider::Init

  .method public virtual instance void  add_CostChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler A_1) cil managed
  {
    // Code size       121 (0x79)
    .maxstack  6
    .locals init (class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper V_0,
             int32 V_1,
             bool V_2)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_2
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
      IL_0014:  brtrue     IL_0022

      IL_0019:  ldarg      0
      IL_001d:  call       instance void Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::Init()
      IL_0022:  newobj     instance void Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::.ctor()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4.0
      IL_0029:  stloc.1
      IL_002a:  ldarg      0
      IL_002e:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
      IL_0033:  ldloc.0
      IL_0034:  castclass  [mscorlib]System.Object
      IL_0039:  ldloca.s   V_1
      IL_003b:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Advise(object,
                                                                                                                    int32&)
      IL_0040:  ldloc.0
      IL_0041:  ldloc.1
      IL_0042:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_dwCookie
      IL_0047:  ldloc.0
      IL_0048:  ldarg      A_1
      IL_004c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_CostChangedDelegate
      IL_0051:  ldarg      0
      IL_0055:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_005a:  ldloc.0
      IL_005b:  castclass  [mscorlib]System.Object
      IL_0060:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::Add(object)
      IL_0065:  pop
      IL_0066:  leave      IL_0078

    }  // end .try
    finally
    {
      IL_006b:  ldloc.2
      IL_006c:  brfalse.s  IL_0077

      IL_006e:  ldarg      0
      IL_0072:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0077:  endfinally
    }  // end handler
    IL_0078:  ret
  } // end of method INetworkCostManagerEvents_EventProvider::add_CostChanged

  .method public virtual instance void  remove_CostChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler A_1) cil managed
  {
    // Code size       246 (0xf6)
    .maxstack  6
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_3
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_0014:  brfalse    IL_00e3

      IL_0019:  ldarg      0
      IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4     0x0
      IL_002d:  stloc.1
      IL_002e:  ldc.i4     0x0
      IL_0033:  ldloc.0
      IL_0034:  bge        IL_00e3

      IL_0039:  ldarg      0
      IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_0042:  ldloc.1
      IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
      IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper
      IL_004d:  stloc.2
      IL_004e:  ldloc.2
      IL_004f:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_CostChangedDelegate
      IL_0054:  ldnull
      IL_0055:  beq        IL_00d4

      IL_005a:  ldloc.2
      IL_005b:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_CostChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_CostChangedDelegate
      IL_0060:  ldarg      A_1
      IL_0064:  castclass  [mscorlib]System.Object
      IL_0069:  callvirt   instance bool [mscorlib]System.Delegate::Equals(object)
      IL_006e:  ldc.i4     0xff
      IL_0073:  and
      IL_0074:  ldc.i4     0x0
      IL_0079:  beq        IL_00d4

      IL_007e:  ldarg      0
      IL_0082:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_0087:  ldloc.1
      IL_0088:  callvirt   instance void [mscorlib]System.Collections.ArrayList::RemoveAt(int32)
      IL_008d:  ldarg      0
      IL_0091:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
      IL_0096:  ldloc.2
      IL_0097:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_dwCookie
      IL_009c:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
      IL_00a1:  ldloc.0
      IL_00a2:  ldc.i4     0x1
      IL_00a7:  bgt        IL_00e3

      IL_00ac:  ldarg      0
      IL_00b0:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
      IL_00b5:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
      IL_00ba:  pop
      IL_00bb:  ldarg      0
      IL_00bf:  ldnull
      IL_00c0:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
      IL_00c5:  ldarg      0
      IL_00c9:  ldnull
      IL_00ca:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_00cf:  br         IL_00e3

      IL_00d4:  ldloc.1
      IL_00d5:  ldc.i4     0x1
      IL_00da:  add
      IL_00db:  stloc.1
      IL_00dc:  ldloc.1
      IL_00dd:  ldloc.0
      IL_00de:  blt        IL_0039

      IL_00e3:  leave      IL_00f5

    }  // end .try
    finally
    {
      IL_00e8:  ldloc.3
      IL_00e9:  brfalse.s  IL_00f4

      IL_00eb:  ldarg      0
      IL_00ef:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00f4:  endfinally
    }  // end handler
    IL_00f5:  ret
  } // end of method INetworkCostManagerEvents_EventProvider::remove_CostChanged

  .method public virtual instance void  add_DataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler A_1) cil managed
  {
    // Code size       121 (0x79)
    .maxstack  6
    .locals init (class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper V_0,
             int32 V_1,
             bool V_2)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_2
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
      IL_0014:  brtrue     IL_0022

      IL_0019:  ldarg      0
      IL_001d:  call       instance void Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::Init()
      IL_0022:  newobj     instance void Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::.ctor()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4.0
      IL_0029:  stloc.1
      IL_002a:  ldarg      0
      IL_002e:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
      IL_0033:  ldloc.0
      IL_0034:  castclass  [mscorlib]System.Object
      IL_0039:  ldloca.s   V_1
      IL_003b:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Advise(object,
                                                                                                                    int32&)
      IL_0040:  ldloc.0
      IL_0041:  ldloc.1
      IL_0042:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_dwCookie
      IL_0047:  ldloc.0
      IL_0048:  ldarg      A_1
      IL_004c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_DataPlanStatusChangedDelegate
      IL_0051:  ldarg      0
      IL_0055:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_005a:  ldloc.0
      IL_005b:  castclass  [mscorlib]System.Object
      IL_0060:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::Add(object)
      IL_0065:  pop
      IL_0066:  leave      IL_0078

    }  // end .try
    finally
    {
      IL_006b:  ldloc.2
      IL_006c:  brfalse.s  IL_0077

      IL_006e:  ldarg      0
      IL_0072:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0077:  endfinally
    }  // end handler
    IL_0078:  ret
  } // end of method INetworkCostManagerEvents_EventProvider::add_DataPlanStatusChanged

  .method public virtual instance void  remove_DataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler A_1) cil managed
  {
    // Code size       246 (0xf6)
    .maxstack  6
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_3
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_0014:  brfalse    IL_00e3

      IL_0019:  ldarg      0
      IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4     0x0
      IL_002d:  stloc.1
      IL_002e:  ldc.i4     0x0
      IL_0033:  ldloc.0
      IL_0034:  bge        IL_00e3

      IL_0039:  ldarg      0
      IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_0042:  ldloc.1
      IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
      IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper
      IL_004d:  stloc.2
      IL_004e:  ldloc.2
      IL_004f:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_DataPlanStatusChangedDelegate
      IL_0054:  ldnull
      IL_0055:  beq        IL_00d4

      IL_005a:  ldloc.2
      IL_005b:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_DataPlanStatusChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_DataPlanStatusChangedDelegate
      IL_0060:  ldarg      A_1
      IL_0064:  castclass  [mscorlib]System.Object
      IL_0069:  callvirt   instance bool [mscorlib]System.Delegate::Equals(object)
      IL_006e:  ldc.i4     0xff
      IL_0073:  and
      IL_0074:  ldc.i4     0x0
      IL_0079:  beq        IL_00d4

      IL_007e:  ldarg      0
      IL_0082:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_0087:  ldloc.1
      IL_0088:  callvirt   instance void [mscorlib]System.Collections.ArrayList::RemoveAt(int32)
      IL_008d:  ldarg      0
      IL_0091:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
      IL_0096:  ldloc.2
      IL_0097:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_dwCookie
      IL_009c:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
      IL_00a1:  ldloc.0
      IL_00a2:  ldc.i4     0x1
      IL_00a7:  bgt        IL_00e3

      IL_00ac:  ldarg      0
      IL_00b0:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
      IL_00b5:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
      IL_00ba:  pop
      IL_00bb:  ldarg      0
      IL_00bf:  ldnull
      IL_00c0:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
      IL_00c5:  ldarg      0
      IL_00c9:  ldnull
      IL_00ca:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
      IL_00cf:  br         IL_00e3

      IL_00d4:  ldloc.1
      IL_00d5:  ldc.i4     0x1
      IL_00da:  add
      IL_00db:  stloc.1
      IL_00dc:  ldloc.1
      IL_00dd:  ldloc.0
      IL_00de:  blt        IL_0039

      IL_00e3:  leave      IL_00f5

    }  // end .try
    finally
    {
      IL_00e8:  ldloc.3
      IL_00e9:  brfalse.s  IL_00f4

      IL_00eb:  ldarg      0
      IL_00ef:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00f4:  endfinally
    }  // end handler
    IL_00f5:  ret
  } // end of method INetworkCostManagerEvents_EventProvider::remove_DataPlanStatusChanged

  .method public specialname rtspecialname 
          instance void  .ctor(object A_1) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  6
    IL_0000:  ldarg      0
    IL_0004:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0009:  ldarg      0
    IL_000d:  ldarg      A_1
    IL_0011:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer
    IL_0016:  ldc.i4.0
    IL_0017:  newobj     instance void [mscorlib]System.WeakReference::.ctor(object,
                                                                             bool)
    IL_001c:  stfld      class [mscorlib]System.WeakReference Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_wkConnectionPointContainer
    IL_0021:  ret
  } // end of method INetworkCostManagerEvents_EventProvider::.ctor

  .method public virtual instance void  Finalize() cil managed
  {
    // Code size       158 (0x9e)
    .maxstack  5
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      .try
      {
        IL_0000:  ldarg      0
        IL_0004:  ldloca.s   V_3
        IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                            bool&)
        IL_000b:  ldarg      0
        IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
        IL_0014:  brfalse    IL_0080

        IL_0019:  ldarg      0
        IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
        IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
        IL_0027:  stloc.0
        IL_0028:  ldc.i4     0x0
        IL_002d:  stloc.1
        IL_002e:  ldc.i4     0x0
        IL_0033:  ldloc.0
        IL_0034:  bge        IL_0071

        IL_0039:  ldarg      0
        IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_aEventSinkHelpers
        IL_0042:  ldloc.1
        IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
        IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper
        IL_004d:  stloc.2
        IL_004e:  ldarg      0
        IL_0052:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
        IL_0057:  ldloc.2
        IL_0058:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_SinkHelper::m_dwCookie
        IL_005d:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
        IL_0062:  ldloc.1
        IL_0063:  ldc.i4     0x1
        IL_0068:  add
        IL_0069:  stloc.1
        IL_006a:  ldloc.1
        IL_006b:  ldloc.0
        IL_006c:  blt        IL_0039

        IL_0071:  ldarg      0
        IL_0075:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::m_ConnectionPoint
        IL_007a:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
        IL_007f:  pop
        IL_0080:  leave      IL_008b

      }  // end .try
      catch [mscorlib]System.Exception 
      {
        IL_0085:  pop
        IL_0086:  leave      IL_008b

      }  // end handler
      IL_008b:  leave      IL_009d

    }  // end .try
    finally
    {
      IL_0090:  ldloc.3
      IL_0091:  brfalse.s  IL_009c

      IL_0093:  ldarg      0
      IL_0097:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_009c:  endfinally
    }  // end handler
    IL_009d:  ret
  } // end of method INetworkCostManagerEvents_EventProvider::Finalize

  .method public virtual instance void  Dispose() cil managed
  {
    // Code size       19 (0x13)
    .maxstack  2
    IL_0000:  ldarg      0
    IL_0004:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider::Finalize()
    IL_0009:  ldarg      0
    IL_000d:  call       void [mscorlib]System.GC::SuppressFinalize(object)
    IL_0012:  ret
  } // end of method INetworkCostManagerEvents_EventProvider::Dispose

} // end of class Vanara.PInvoke.NetListMgr.INetworkCostManagerEvents_EventProvider

.class public auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper
       extends [mscorlib]System.Object
       implements Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ClassInterfaceType) = ( 01 00 00 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.TypeLibTypeFlags) = ( 01 00 10 00 00 00 00 00 ) 
  .field public class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler m_ConnectionCostChangedDelegate
  .field public class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler m_ConnectionDataPlanStatusChangedDelegate
  .field public int32 m_dwCookie
  .method public virtual instance void  ConnectionCostChanged(valuetype [mscorlib]System.Guid A_1,
                                                              valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST A_2) cil managed
  {
    // Code size       38 (0x26)
    .maxstack  3
    IL_0000:  ldarg      0
    IL_0004:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_ConnectionCostChangedDelegate
    IL_0009:  brfalse    IL_0025

    IL_000e:  ldarg      0
    IL_0012:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_ConnectionCostChangedDelegate
    IL_0017:  ldarg      A_1
    IL_001b:  ldarg      A_2
    IL_001f:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler::Invoke(valuetype [mscorlib]System.Guid,
                                                                                                                                        valuetype Vanara.PInvoke.NetListMgr.NLM_CONNECTION_COST)
    IL_0024:  ret

    IL_0025:  ret
  } // end of method INetworkConnectionCostEvents_SinkHelper::ConnectionCostChanged

  .method public virtual instance void  ConnectionDataPlanStatusChanged(valuetype [mscorlib]System.Guid A_1) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  2
    IL_0000:  ldarg      0
    IL_0004:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_ConnectionDataPlanStatusChangedDelegate
    IL_0009:  brfalse    IL_0021

    IL_000e:  ldarg      0
    IL_0012:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_ConnectionDataPlanStatusChangedDelegate
    IL_0017:  ldarg      A_1
    IL_001b:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler::Invoke(valuetype [mscorlib]System.Guid)
    IL_0020:  ret

    IL_0021:  ret
  } // end of method INetworkConnectionCostEvents_SinkHelper::ConnectionDataPlanStatusChanged

  .method assembly specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       44 (0x2c)
    .maxstack  4
    IL_0000:  ldarg      0
    IL_0004:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0009:  ldarg      0
    IL_000d:  ldc.i4     0x0
    IL_0012:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_dwCookie
    IL_0017:  ldarg      0
    IL_001b:  ldnull
    IL_001c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_ConnectionCostChangedDelegate
    IL_0021:  ldarg      0
    IL_0025:  ldnull
    IL_0026:  stfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_ConnectionDataPlanStatusChangedDelegate
    IL_002b:  ret
  } // end of method INetworkConnectionCostEvents_SinkHelper::.ctor

} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper

.class private auto ansi sealed Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider
       extends [mscorlib]System.Object
       implements Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_Event,
                  [mscorlib]System.IDisposable
{
  .field private class [mscorlib]System.WeakReference m_wkConnectionPointContainer
  .field private class [mscorlib]System.Collections.ArrayList m_aEventSinkHelpers
  .field private class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint m_ConnectionPoint
  .method private instance void  Init() cil managed
  {
    // Code size       271 (0x10f)
    .maxstack  5
    .locals init (class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint V_0,
             valuetype [mscorlib]System.Guid V_1,
             uint8[] V_2)
    IL_0000:  ldnull
    IL_0001:  stloc.0
    IL_0002:  ldc.i4     0x10
    IL_0007:  newarr     [mscorlib]System.Byte
    IL_000c:  stloc.2
    IL_000d:  ldloc.2
    IL_000e:  ldc.i4     0x0
    IL_0013:  ldc.i4     0xb
    IL_0018:  stelem.i1
    IL_0019:  ldloc.2
    IL_001a:  ldc.i4     0x1
    IL_001f:  ldc.i4     0x0
    IL_0024:  stelem.i1
    IL_0025:  ldloc.2
    IL_0026:  ldc.i4     0x2
    IL_002b:  ldc.i4     0xb0
    IL_0030:  stelem.i1
    IL_0031:  ldloc.2
    IL_0032:  ldc.i4     0x3
    IL_0037:  ldc.i4     0xdc
    IL_003c:  stelem.i1
    IL_003d:  ldloc.2
    IL_003e:  ldc.i4     0x4
    IL_0043:  ldc.i4     0xf
    IL_0048:  stelem.i1
    IL_0049:  ldloc.2
    IL_004a:  ldc.i4     0x5
    IL_004f:  ldc.i4     0x57
    IL_0054:  stelem.i1
    IL_0055:  ldloc.2
    IL_0056:  ldc.i4     0x6
    IL_005b:  ldc.i4     0x9b
    IL_0060:  stelem.i1
    IL_0061:  ldloc.2
    IL_0062:  ldc.i4     0x7
    IL_0067:  ldc.i4     0x4a
    IL_006c:  stelem.i1
    IL_006d:  ldloc.2
    IL_006e:  ldc.i4     0x8
    IL_0073:  ldc.i4     0x8d
    IL_0078:  stelem.i1
    IL_0079:  ldloc.2
    IL_007a:  ldc.i4     0x9
    IL_007f:  ldc.i4     0x69
    IL_0084:  stelem.i1
    IL_0085:  ldloc.2
    IL_0086:  ldc.i4     0xa
    IL_008b:  ldc.i4     0x19
    IL_0090:  stelem.i1
    IL_0091:  ldloc.2
    IL_0092:  ldc.i4     0xb
    IL_0097:  ldc.i4     0x9f
    IL_009c:  stelem.i1
    IL_009d:  ldloc.2
    IL_009e:  ldc.i4     0xc
    IL_00a3:  ldc.i4     0xdb
    IL_00a8:  stelem.i1
    IL_00a9:  ldloc.2
    IL_00aa:  ldc.i4     0xd
    IL_00af:  ldc.i4     0xa5
    IL_00b4:  stelem.i1
    IL_00b5:  ldloc.2
    IL_00b6:  ldc.i4     0xe
    IL_00bb:  ldc.i4     0x72
    IL_00c0:  stelem.i1
    IL_00c1:  ldloc.2
    IL_00c2:  ldc.i4     0xf
    IL_00c7:  ldc.i4     0x3b
    IL_00cc:  stelem.i1
    IL_00cd:  ldloca.s   V_1
    IL_00cf:  ldloc.2
    IL_00d0:  call       instance void [mscorlib]System.Guid::.ctor(uint8[])
    IL_00d5:  ldarg      0
    IL_00d9:  ldfld      class [mscorlib]System.WeakReference Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_wkConnectionPointContainer
    IL_00de:  callvirt   instance object [mscorlib]System.WeakReference::get_Target()
    IL_00e3:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer
    IL_00e8:  ldloca.s   V_1
    IL_00ea:  ldloca.s   V_0
    IL_00ec:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer::FindConnectionPoint(valuetype [mscorlib]System.Guid&,
                                                                                                                                        class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint&)
    IL_00f1:  ldarg      0
    IL_00f5:  ldloc.0
    IL_00f6:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint
    IL_00fb:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
    IL_0100:  ldarg      0
    IL_0104:  newobj     instance void [mscorlib]System.Collections.ArrayList::.ctor()
    IL_0109:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
    IL_010e:  ret
  } // end of method INetworkConnectionCostEvents_EventProvider::Init

  .method public virtual instance void  add_ConnectionCostChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler A_1) cil managed
  {
    // Code size       121 (0x79)
    .maxstack  6
    .locals init (class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper V_0,
             int32 V_1,
             bool V_2)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_2
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
      IL_0014:  brtrue     IL_0022

      IL_0019:  ldarg      0
      IL_001d:  call       instance void Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::Init()
      IL_0022:  newobj     instance void Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::.ctor()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4.0
      IL_0029:  stloc.1
      IL_002a:  ldarg      0
      IL_002e:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
      IL_0033:  ldloc.0
      IL_0034:  castclass  [mscorlib]System.Object
      IL_0039:  ldloca.s   V_1
      IL_003b:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Advise(object,
                                                                                                                    int32&)
      IL_0040:  ldloc.0
      IL_0041:  ldloc.1
      IL_0042:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_dwCookie
      IL_0047:  ldloc.0
      IL_0048:  ldarg      A_1
      IL_004c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_ConnectionCostChangedDelegate
      IL_0051:  ldarg      0
      IL_0055:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
      IL_005a:  ldloc.0
      IL_005b:  castclass  [mscorlib]System.Object
      IL_0060:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::Add(object)
      IL_0065:  pop
      IL_0066:  leave      IL_0078

    }  // end .try
    finally
    {
      IL_006b:  ldloc.2
      IL_006c:  brfalse.s  IL_0077

      IL_006e:  ldarg      0
      IL_0072:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0077:  endfinally
    }  // end handler
    IL_0078:  ret
  } // end of method INetworkConnectionCostEvents_EventProvider::add_ConnectionCostChanged

  .method public virtual instance void  remove_ConnectionCostChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler A_1) cil managed
  {
    // Code size       246 (0xf6)
    .maxstack  6
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_3
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
      IL_0014:  brfalse    IL_00e3

      IL_0019:  ldarg      0
      IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
      IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4     0x0
      IL_002d:  stloc.1
      IL_002e:  ldc.i4     0x0
      IL_0033:  ldloc.0
      IL_0034:  bge        IL_00e3

      IL_0039:  ldarg      0
      IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
      IL_0042:  ldloc.1
      IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
      IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper
      IL_004d:  stloc.2
      IL_004e:  ldloc.2
      IL_004f:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_ConnectionCostChangedDelegate
      IL_0054:  ldnull
      IL_0055:  beq        IL_00d4

      IL_005a:  ldloc.2
      IL_005b:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionCostChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_ConnectionCostChangedDelegate
      IL_0060:  ldarg      A_1
      IL_0064:  castclass  [mscorlib]System.Object
      IL_0069:  callvirt   instance bool [mscorlib]System.Delegate::Equals(object)
      IL_006e:  ldc.i4     0xff
      IL_0073:  and
      IL_0074:  ldc.i4     0x0
      IL_0079:  beq        IL_00d4

      IL_007e:  ldarg      0
      IL_0082:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
      IL_0087:  ldloc.1
      IL_0088:  callvirt   instance void [mscorlib]System.Collections.ArrayList::RemoveAt(int32)
      IL_008d:  ldarg      0
      IL_0091:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
      IL_0096:  ldloc.2
      IL_0097:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_dwCookie
      IL_009c:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
      IL_00a1:  ldloc.0
      IL_00a2:  ldc.i4     0x1
      IL_00a7:  bgt        IL_00e3

      IL_00ac:  ldarg      0
      IL_00b0:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
      IL_00b5:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
      IL_00ba:  pop
      IL_00bb:  ldarg      0
      IL_00bf:  ldnull
      IL_00c0:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
      IL_00c5:  ldarg      0
      IL_00c9:  ldnull
      IL_00ca:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
      IL_00cf:  br         IL_00e3

      IL_00d4:  ldloc.1
      IL_00d5:  ldc.i4     0x1
      IL_00da:  add
      IL_00db:  stloc.1
      IL_00dc:  ldloc.1
      IL_00dd:  ldloc.0
      IL_00de:  blt        IL_0039

      IL_00e3:  leave      IL_00f5

    }  // end .try
    finally
    {
      IL_00e8:  ldloc.3
      IL_00e9:  brfalse.s  IL_00f4

      IL_00eb:  ldarg      0
      IL_00ef:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00f4:  endfinally
    }  // end handler
    IL_00f5:  ret
  } // end of method INetworkConnectionCostEvents_EventProvider::remove_ConnectionCostChanged

  .method public virtual instance void  add_ConnectionDataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler A_1) cil managed
  {
    // Code size       121 (0x79)
    .maxstack  6
    .locals init (class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper V_0,
             int32 V_1,
             bool V_2)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_2
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
      IL_0014:  brtrue     IL_0022

      IL_0019:  ldarg      0
      IL_001d:  call       instance void Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::Init()
      IL_0022:  newobj     instance void Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::.ctor()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4.0
      IL_0029:  stloc.1
      IL_002a:  ldarg      0
      IL_002e:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
      IL_0033:  ldloc.0
      IL_0034:  castclass  [mscorlib]System.Object
      IL_0039:  ldloca.s   V_1
      IL_003b:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Advise(object,
                                                                                                                    int32&)
      IL_0040:  ldloc.0
      IL_0041:  ldloc.1
      IL_0042:  stfld      int32 Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_dwCookie
      IL_0047:  ldloc.0
      IL_0048:  ldarg      A_1
      IL_004c:  stfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_ConnectionDataPlanStatusChangedDelegate
      IL_0051:  ldarg      0
      IL_0055:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
      IL_005a:  ldloc.0
      IL_005b:  castclass  [mscorlib]System.Object
      IL_0060:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::Add(object)
      IL_0065:  pop
      IL_0066:  leave      IL_0078

    }  // end .try
    finally
    {
      IL_006b:  ldloc.2
      IL_006c:  brfalse.s  IL_0077

      IL_006e:  ldarg      0
      IL_0072:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0077:  endfinally
    }  // end handler
    IL_0078:  ret
  } // end of method INetworkConnectionCostEvents_EventProvider::add_ConnectionDataPlanStatusChanged

  .method public virtual instance void  remove_ConnectionDataPlanStatusChanged(class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler A_1) cil managed
  {
    // Code size       246 (0xf6)
    .maxstack  6
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      IL_0000:  ldarg      0
      IL_0004:  ldloca.s   V_3
      IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                          bool&)
      IL_000b:  ldarg      0
      IL_000f:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
      IL_0014:  brfalse    IL_00e3

      IL_0019:  ldarg      0
      IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
      IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
      IL_0027:  stloc.0
      IL_0028:  ldc.i4     0x0
      IL_002d:  stloc.1
      IL_002e:  ldc.i4     0x0
      IL_0033:  ldloc.0
      IL_0034:  bge        IL_00e3

      IL_0039:  ldarg      0
      IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
      IL_0042:  ldloc.1
      IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
      IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper
      IL_004d:  stloc.2
      IL_004e:  ldloc.2
      IL_004f:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_ConnectionDataPlanStatusChangedDelegate
      IL_0054:  ldnull
      IL_0055:  beq        IL_00d4

      IL_005a:  ldloc.2
      IL_005b:  ldfld      class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_ConnectionDataPlanStatusChangedEventHandler Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_ConnectionDataPlanStatusChangedDelegate
      IL_0060:  ldarg      A_1
      IL_0064:  castclass  [mscorlib]System.Object
      IL_0069:  callvirt   instance bool [mscorlib]System.Delegate::Equals(object)
      IL_006e:  ldc.i4     0xff
      IL_0073:  and
      IL_0074:  ldc.i4     0x0
      IL_0079:  beq        IL_00d4

      IL_007e:  ldarg      0
      IL_0082:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
      IL_0087:  ldloc.1
      IL_0088:  callvirt   instance void [mscorlib]System.Collections.ArrayList::RemoveAt(int32)
      IL_008d:  ldarg      0
      IL_0091:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
      IL_0096:  ldloc.2
      IL_0097:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_dwCookie
      IL_009c:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
      IL_00a1:  ldloc.0
      IL_00a2:  ldc.i4     0x1
      IL_00a7:  bgt        IL_00e3

      IL_00ac:  ldarg      0
      IL_00b0:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
      IL_00b5:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
      IL_00ba:  pop
      IL_00bb:  ldarg      0
      IL_00bf:  ldnull
      IL_00c0:  stfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
      IL_00c5:  ldarg      0
      IL_00c9:  ldnull
      IL_00ca:  stfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
      IL_00cf:  br         IL_00e3

      IL_00d4:  ldloc.1
      IL_00d5:  ldc.i4     0x1
      IL_00da:  add
      IL_00db:  stloc.1
      IL_00dc:  ldloc.1
      IL_00dd:  ldloc.0
      IL_00de:  blt        IL_0039

      IL_00e3:  leave      IL_00f5

    }  // end .try
    finally
    {
      IL_00e8:  ldloc.3
      IL_00e9:  brfalse.s  IL_00f4

      IL_00eb:  ldarg      0
      IL_00ef:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00f4:  endfinally
    }  // end handler
    IL_00f5:  ret
  } // end of method INetworkConnectionCostEvents_EventProvider::remove_ConnectionDataPlanStatusChanged

  .method public specialname rtspecialname 
          instance void  .ctor(object A_1) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  6
    IL_0000:  ldarg      0
    IL_0004:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0009:  ldarg      0
    IL_000d:  ldarg      A_1
    IL_0011:  castclass  [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPointContainer
    IL_0016:  ldc.i4.0
    IL_0017:  newobj     instance void [mscorlib]System.WeakReference::.ctor(object,
                                                                             bool)
    IL_001c:  stfld      class [mscorlib]System.WeakReference Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_wkConnectionPointContainer
    IL_0021:  ret
  } // end of method INetworkConnectionCostEvents_EventProvider::.ctor

  .method public virtual instance void  Finalize() cil managed
  {
    // Code size       158 (0x9e)
    .maxstack  5
    .locals init (int32 V_0,
             int32 V_1,
             class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper V_2,
             bool V_3)
    .try
    {
      .try
      {
        IL_0000:  ldarg      0
        IL_0004:  ldloca.s   V_3
        IL_0006:  call       void [mscorlib]System.Threading.Monitor::Enter(object,
                                                                            bool&)
        IL_000b:  ldarg      0
        IL_000f:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
        IL_0014:  brfalse    IL_0080

        IL_0019:  ldarg      0
        IL_001d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
        IL_0022:  callvirt   instance int32 [mscorlib]System.Collections.ArrayList::get_Count()
        IL_0027:  stloc.0
        IL_0028:  ldc.i4     0x0
        IL_002d:  stloc.1
        IL_002e:  ldc.i4     0x0
        IL_0033:  ldloc.0
        IL_0034:  bge        IL_0071

        IL_0039:  ldarg      0
        IL_003d:  ldfld      class [mscorlib]System.Collections.ArrayList Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_aEventSinkHelpers
        IL_0042:  ldloc.1
        IL_0043:  callvirt   instance object [mscorlib]System.Collections.ArrayList::get_Item(int32)
        IL_0048:  castclass  Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper
        IL_004d:  stloc.2
        IL_004e:  ldarg      0
        IL_0052:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
        IL_0057:  ldloc.2
        IL_0058:  ldfld      int32 Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_SinkHelper::m_dwCookie
        IL_005d:  callvirt   instance void [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint::Unadvise(int32)
        IL_0062:  ldloc.1
        IL_0063:  ldc.i4     0x1
        IL_0068:  add
        IL_0069:  stloc.1
        IL_006a:  ldloc.1
        IL_006b:  ldloc.0
        IL_006c:  blt        IL_0039

        IL_0071:  ldarg      0
        IL_0075:  ldfld      class [mscorlib]System.Runtime.InteropServices.ComTypes.IConnectionPoint Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::m_ConnectionPoint
        IL_007a:  call       int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReleaseComObject(object)
        IL_007f:  pop
        IL_0080:  leave      IL_008b

      }  // end .try
      catch [mscorlib]System.Exception 
      {
        IL_0085:  pop
        IL_0086:  leave      IL_008b

      }  // end handler
      IL_008b:  leave      IL_009d

    }  // end .try
    finally
    {
      IL_0090:  ldloc.3
      IL_0091:  brfalse.s  IL_009c

      IL_0093:  ldarg      0
      IL_0097:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_009c:  endfinally
    }  // end handler
    IL_009d:  ret
  } // end of method INetworkConnectionCostEvents_EventProvider::Finalize

  .method public virtual instance void  Dispose() cil managed
  {
    // Code size       19 (0x13)
    .maxstack  2
    IL_0000:  ldarg      0
    IL_0004:  callvirt   instance void Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider::Finalize()
    IL_0009:  ldarg      0
    IL_000d:  call       void [mscorlib]System.GC::SuppressFinalize(object)
    IL_0012:  ret
  } // end of method INetworkConnectionCostEvents_EventProvider::Dispose

} // end of class Vanara.PInvoke.NetListMgr.INetworkConnectionCostEvents_EventProvider


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file NetListMgr.res
