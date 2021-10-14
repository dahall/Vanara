using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.NetApi32;

namespace Vanara
{
    /// <summary>Represents a local group on a server.</summary>
    public class LocalGroup : IEquatable<LocalGroup>
    {
        private LocalGroupMembers members;

        internal LocalGroup(string target, string name)
        {
            Target = target;
            Name = name;
        }

        /// <summary>
        /// A remark associated with the local group. This member can be a <see langword="null"/> string. The comment can have as many as
        /// MAXCOMMENTSZ characters.
        /// </summary>
        public string Comment
        {
            get => NetLocalGroupGetInfo<LOCALGROUP_INFO_1>(Target, Name).lgrpi1_comment;
            set => NetLocalGroupSetInfo(Target, Name, new LOCALGROUP_INFO_1002 { lgrpi1002_comment = value }, 1002);
        }

        /// <summary>Gets the collection of members for this local group.</summary>
        /// <value>The collection of members for this local group.</value>
        public LocalGroupMembers Members => members ??= new LocalGroupMembers(this);

        /// <summary>The local group name.</summary>
        public string Name { get; }

        /// <summary>
        /// Gets a string that specifies the DNS or NetBIOS name of the remote server on which the local group resides. If this value is
        /// <see langword="null"/>, the local computer is assumed.
        /// </summary>
        /// <value>The target server.</value>
        public string Target { get; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(LocalGroup other) => other?.Name == Name && other.Target == Target;
    }

    /// <summary>Represents a colleciton of local group members.</summary>
    public class LocalGroupMembers : ICollection<PSID>
    {
        private readonly LocalGroup localGroup;

        internal LocalGroupMembers(LocalGroup localGroup) => this.localGroup = localGroup;

        /// <summary>Gets the number of elements contained in the collection.</summary>
        /// <value>The number of elements contained in the collection.</value>
        public int Count => GetMemberSids().Count();

        /// <summary>Gets a value indicating whether the collection is read only.</summary>
        /// <value><see langword="true"/> if the collection is read only; otherwise, <see langword="false"/>.</value>
        bool ICollection<PSID>.IsReadOnly => false;

        /// <summary>
        /// Adds membership of one user account or global group account to the local group. The function does not change the membership
        /// status of users or global groups that are currently members of the local group.
        /// </summary>
        /// <param name="member">The SID of the new local group member.</param>
        /// <remarks>
        /// <para>
        /// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
        /// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call
        /// this function. On a member server or workstation, only Administrators and Power Users can call this function. For more
        /// information, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
        /// tokens, see Access Control Model.
        /// </para>
        /// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
        /// </remarks>
        public void Add(PSID member) => AddRange(new PSID[] { member });

        /// <summary>
        /// Adds membership of one or more existing user accounts or global group accounts to the local group. The function does not change
        /// the membership status of users or global groups that are currently members of the local group.
        /// </summary>
        /// <param name="members">The SIDs of the new local group members.</param>
        /// <remarks>
        /// <para>
        /// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
        /// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call
        /// this function. On a member server or workstation, only Administrators and Power Users can call this function. For more
        /// information, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
        /// tokens, see Access Control Model.
        /// </para>
        /// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
        /// </remarks>
        public void AddRange(IEnumerable<PSID> members)
        {
            LOCALGROUP_MEMBERS_INFO_0[] a = members.Select(p => new LOCALGROUP_MEMBERS_INFO_0 { lgrmi0_sid = p }).ToArray();
            NetLocalGroupAddMembers(localGroup.Target, localGroup.Name, a, 0);
        }

        /// <summary>Removes all items from the collection.</summary>
        public void Clear() => NetLocalGroupSetMembers(localGroup.Target, localGroup.Name, new LOCALGROUP_MEMBERS_INFO_0[0], 0); // Remove(GetMemberSids());

        /// <summary>Determines whether the collection contains the specified SID.</summary>
        /// <param name="item">The pointer to the SID to find.</param>
        /// <returns><see langword="true"/> if the collection contains the specified SID, otherwise, <see langword="false"/>.</returns>
        public bool Contains(PSID item) => GetMemberSids().Contains(item);

        /// <summary>Copies the elements of the collection to an Array, starting at a particular Array index.</summary>
        /// <param name="array">
        /// The one-dimensional Array that is the destination of the elements copied from the collection. The Array must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(PSID[] array, int arrayIndex)
        {
            PSID[] a = GetMemberSids().ToArray();
            Array.Copy(a, 0, array, arrayIndex, a.Length);
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<PSID> GetEnumerator() => GetMemberSids().GetEnumerator();

        /// <summary>Removes one member from an existing local group. Local group members can be users or global groups.</summary>
        /// <param name="member">The SID of the member to be removed.</param>
        /// <remarks>
        /// <para>
        /// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
        /// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call
        /// this function. On a member server or workstation, only Administrators and Power Users can call this function. For more
        /// information, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
        /// tokens, see Access Control Model.
        /// </para>
        /// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
        /// </remarks>
        public bool Remove(PSID member)
        {
            try { Remove(new[] { member }); return true; }
            catch { return false; }
        }

        /// <summary>Removes one or more members from an existing local group. Local group members can be users or global groups.</summary>
        /// <param name="members">The SIDs of the members to be removed.</param>
        /// <remarks>
        /// <para>
        /// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
        /// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call
        /// this function. On a member server or workstation, only Administrators and Power Users can call this function. For more
        /// information, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
        /// tokens, see Access Control Model.
        /// </para>
        /// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
        /// </remarks>
        public void Remove(IEnumerable<PSID> members)
        {
            LOCALGROUP_MEMBERS_INFO_0[] a = members.Select(p => new LOCALGROUP_MEMBERS_INFO_0 { lgrmi0_sid = p }).ToArray();
            NetLocalGroupDelMembers(localGroup.Target, localGroup.Name, a, 0);
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private IEnumerable<PSID> GetMemberSids() => NetLocalGroupGetMembers<LOCALGROUP_MEMBERS_INFO_0>(localGroup.Target, localGroup.Name, 0).Select(i => i.lgrmi0_sid);
    }

    /// <summary>Represents the collection of local groups on a server.</summary>
    public class LocalGroups : ICollection<LocalGroup>
    {
        /// <summary>Initializes a new instance of the <see cref="UserAccounts"/> class.</summary>
        /// <param name="target">
        /// The DNS or NetBIOS name of the remote server on which the user account resides. If this value is <see langword="null"/>, the
        /// local computer is assumed.
        /// </param>
        public LocalGroups(string target = null) => Target = target;

        /// <summary>
        /// Gets the DNS or NetBIOS name of the remote server on which the user account resides. If this value is <see langword="null"/>,
        /// the local computer is assumed.
        /// </summary>
        /// <value>The target.</value>
        public string Target { get; }

        /// <summary>Gets the number of elements contained in the collection.</summary>
        /// <value>The number of elements contained in the collection.</value>
        public int Count => Enumerate().Count();

        /// <summary>Gets a value indicating whether the collection is read only.</summary>
        /// <value><see langword="true"/> if the collection is read only; otherwise, <see langword="false"/>.</value>
        bool ICollection<LocalGroup>.IsReadOnly => false;

        /// <summary>
        /// Creates a local group in the security database, which is the security accounts manager (SAM) database or, in the case of domain
        /// controllers, the Active Directory.
        /// </summary>
        /// <param name="name">The local group name.</param>
        /// <returns>On success, the <see cref="LocalGroup"/> instance representing the created local group.</returns>
        /// <remarks>
        /// <para>
        /// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
        /// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call
        /// this function. On a member server or workstation, only Administrators and Power Users can call this function. For more
        /// information, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
        /// tokens, see Access Control Model.
        /// </para>
        /// <para>
        /// The security descriptor of the user container is used to perform the access check for this function. The caller must be able to
        /// create child objects of the group class.
        /// </para>
        /// </remarks>
        public LocalGroup Add(string name)
        {
            NetLocalGroupAdd(Target, new LOCALGROUP_INFO_0 { lgrpi0_name = name }, 0);
            return new LocalGroup(Target, name);
        }

        /// <summary>Removes all items from the collection.</summary>
        public void Clear()
        {
            foreach (LocalGroup a in Enumerate().ToArray())
            {
                Remove(a);
            }
        }

        /// <summary>Determines whether the collection contains the specified user account.</summary>
        /// <param name="item">The user account to find.</param>
        /// <returns><see langword="true"/> if the collection contains the specified user account, otherwise, <see langword="false"/>.</returns>
        public bool Contains(LocalGroup item) => Enumerate().Contains(item);

        /// <summary>Copies the elements of the collection to an Array, starting at a particular Array index.</summary>
        /// <param name="array">
        /// The one-dimensional Array that is the destination of the elements copied from the collection. The Array must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(LocalGroup[] array, int arrayIndex)
        {
            LocalGroup[] a = Enumerate().ToArray();
            Array.Copy(a, 0, array, arrayIndex, a.Length);
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<LocalGroup> GetEnumerator() => Enumerate().GetEnumerator();

        /// <summary>
        /// Deletes this local group and all its members from the security database, which is the security accounts manager (SAM) database
        /// or, in the case of domain controllers, the Active Directory.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
        /// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call
        /// this function. On a member server or workstation, only Administrators and Power Users can call this function. For more
        /// information, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
        /// tokens, see Access Control Model.
        /// </para>
        /// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
        /// </remarks>
        public bool Remove(LocalGroup localGroup) => NetLocalGroupDel(Target, localGroup.Name).Succeeded;

        /// <inheritdoc/>
        void ICollection<LocalGroup>.Add(LocalGroup item) => throw new NotImplementedException();

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private IEnumerable<LocalGroup> Enumerate() => NetLocalGroupEnum<LOCALGROUP_INFO_0>(Target).Select(i => new LocalGroup(Target, i.lgrpi0_name));
    }
}