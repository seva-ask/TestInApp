// This file is automatically generated and not supposed to be modified.
using System;
using Boolean = System.Boolean;
using String = System.String;
using List = Android.Runtime.JavaList;
using Map = Android.Runtime.JavaDictionary;
using Android.Content;

namespace Org.Onepf.Oms
{
	public interface IOpenAppstore : global::Android.OS.IInterface
	{
		String GetAppstoreName ();
		bool IsPackageInstaller (String packageName);
		bool IsBillingAvailable (String packageName);
		int GetPackageVersion (String packageName);
		Android.Content.Intent GetBillingServiceIntent ();
		Android.Content.Intent GetProductPageIntent (String packageName);
		Android.Content.Intent GetRateItPageIntent (String packageName);
		Android.Content.Intent GetSameDeveloperPageIntent (String packageName);
		bool AreOutsideLinksAllowed ();
	}

	public abstract class IOpenAppstoreStub : global::Android.OS.Binder, global::Android.OS.IInterface, Org.Onepf.Oms.IOpenAppstore
	{
		const string descriptor = "org.onepf.oms.IOpenAppstore";
		public IOpenAppstoreStub ()
		{
			this.AttachInterface (this, descriptor);
		}

		public static Org.Onepf.Oms.IOpenAppstore AsInterface (global::Android.OS.IBinder obj)
		{
			if (obj == null)
				return null;
			var iin = (global::Android.OS.IInterface) obj.QueryLocalInterface (descriptor);
			if (iin != null && iin is Org.Onepf.Oms.IOpenAppstore)
				return (Org.Onepf.Oms.IOpenAppstore) iin;
			return new Proxy (obj);
		}

		public global::Android.OS.IBinder AsBinder ()
		{
			return this;
		}

		protected override bool OnTransact (int code, global::Android.OS.Parcel data, global::Android.OS.Parcel reply, int flags)
		{
			switch (code) {
			case global::Android.OS.BinderConsts.InterfaceTransaction:
				reply.WriteString (descriptor);
				return true;

			case TransactionGetAppstoreName: {
				data.EnforceInterface (descriptor);
				var result = this.GetAppstoreName ();
				reply.WriteString (result);
				return true;
				}

			case TransactionIsPackageInstaller: {
				data.EnforceInterface (descriptor);
				String arg0 = default (String);
				arg0 = data.ReadString ();
				var result = this.IsPackageInstaller (arg0);
				reply.WriteInt (result ? 1 : 0);
				return true;
				}

			case TransactionIsBillingAvailable: {
				data.EnforceInterface (descriptor);
				String arg0 = default (String);
				arg0 = data.ReadString ();
				var result = this.IsBillingAvailable (arg0);
				reply.WriteInt (result ? 1 : 0);
				return true;
				}

			case TransactionGetPackageVersion: {
				data.EnforceInterface (descriptor);
				String arg0 = default (String);
				arg0 = data.ReadString ();
				var result = this.GetPackageVersion (arg0);
				reply.WriteInt (result);
				return true;
				}

			case TransactionGetBillingServiceIntent: {
				data.EnforceInterface (descriptor);
				var result = this.GetBillingServiceIntent ();
				if ((result != null)) {
					reply.WriteInt(1);
					result.WriteToParcel(reply, Android.OS.ParcelableWriteFlags.ReturnValue);
				}
				else
				{
					reply.WriteInt (0);
				}
				return true;
				}

			case TransactionGetProductPageIntent: {
				data.EnforceInterface (descriptor);
				String arg0;
				arg0 = data.ReadString ();
				var result = this.GetProductPageIntent (arg0);
				if ((result != null)) {
					reply.WriteInt(1);
					result.WriteToParcel(reply, Android.OS.ParcelableWriteFlags.ReturnValue);
				}
				else
				{
					reply.WriteInt (0);
				}
				return true;
				}

			case TransactionGetRateItPageIntent: {
				data.EnforceInterface (descriptor);
				String arg0;
				arg0 = data.ReadString ();
				var result = this.GetRateItPageIntent (arg0);
				if ((result != null)) {
					reply.WriteInt(1);
					result.WriteToParcel(reply, Android.OS.ParcelableWriteFlags.ReturnValue);
				}
				else
				{
					reply.WriteInt (0);
				}
				return true;
				}

			case TransactionGetSameDeveloperPageIntent: {
				data.EnforceInterface (descriptor);
				String arg0;
				arg0 = data.ReadString ();
				var result = this.GetSameDeveloperPageIntent (arg0);
				if ((result != null)) {
					reply.WriteInt(1);
					result.WriteToParcel(reply, Android.OS.ParcelableWriteFlags.ReturnValue);
				}
				else
				{
					reply.WriteInt (0);
				}
				return true;
				}

			case TransactionAreOutsideLinksAllowed: {
				data.EnforceInterface (descriptor);
				var result = this.AreOutsideLinksAllowed ();
				reply.WriteInt (result ? 1 : 0);
				return true;
				}

			}
			return base.OnTransact (code, data, reply, flags);
		}

		public class Proxy : Java.Lang.Object, Org.Onepf.Oms.IOpenAppstore
		{
			global::Android.OS.IBinder remote;

			public Proxy (global::Android.OS.IBinder remote)
			{
				this.remote = remote;
			}

			public global::Android.OS.IBinder AsBinder ()
			{
				return remote;
			}

			public string GetInterfaceDescriptor ()
			{
				return descriptor;
			}

			public String GetAppstoreName ()
			{
				global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain ();

				global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain ();
				String __result;

				try {
					__data.WriteInterfaceToken (descriptor);
					remote.Transact (IOpenAppstoreStub.TransactionGetAppstoreName, __data, __reply, 0);
					__reply.ReadException ();
					__result = __reply.ReadString ();

				} finally {
					__reply.Recycle ();
					__data.Recycle ();
				}
				return __result;

			}


			public bool IsPackageInstaller (String packageName)
			{
				global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain ();

				global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain ();
				bool __result;

				try {
					__data.WriteInterfaceToken (descriptor);
					__data.WriteString (packageName);
					remote.Transact (IOpenAppstoreStub.TransactionIsPackageInstaller, __data, __reply, 0);
					__reply.ReadException ();
					__result = __reply.ReadInt () != 0;

				} finally {
					__reply.Recycle ();
					__data.Recycle ();
				}
				return __result;

			}


			public bool IsBillingAvailable (String packageName)
			{
				global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain ();

				global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain ();
				bool __result;

				try {
					__data.WriteInterfaceToken (descriptor);
					__data.WriteString (packageName);
					remote.Transact (IOpenAppstoreStub.TransactionIsBillingAvailable, __data, __reply, 0);
					__reply.ReadException ();
					__result = __reply.ReadInt () != 0;

				} finally {
					__reply.Recycle ();
					__data.Recycle ();
				}
				return __result;

			}


			public int GetPackageVersion (String packageName)
			{
				global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain ();

				global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain ();
				int __result;

				try {
					__data.WriteInterfaceToken (descriptor);
					__data.WriteString (packageName);
					remote.Transact (IOpenAppstoreStub.TransactionGetPackageVersion, __data, __reply, 0);
					__reply.ReadException ();
					__result = __reply.ReadInt ();

				} finally {
					__reply.Recycle ();
					__data.Recycle ();
				}
				return __result;

			}


			public Android.Content.Intent GetBillingServiceIntent ()
			{
				global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain ();

				global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain ();
				Android.Content.Intent __result;

				try {
					__data.WriteInterfaceToken (descriptor);
					remote.Transact (IOpenAppstoreStub.TransactionGetBillingServiceIntent, __data, __reply, 0);
					__reply.ReadException ();
					__result = Android.Content.Intent.Creator.CreateFromParcel(__reply) as Android.Content.Intent;

				} finally {
					__reply.Recycle ();
					__data.Recycle ();
				}
				return __result;

			}


			public Android.Content.Intent GetProductPageIntent (String packageName)
			{
				global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain ();

				global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain ();
				Android.Content.Intent __result;

				try {
					__data.WriteInterfaceToken (descriptor);
					__data.WriteString (packageName);
					remote.Transact (IOpenAppstoreStub.TransactionGetProductPageIntent, __data, __reply, 0);
					__reply.ReadException ();
					__result = Android.Content.Intent.Creator.CreateFromParcel(__reply) as Android.Content.Intent;

				} finally {
					__reply.Recycle ();
					__data.Recycle ();
				}
				return __result;

			}


			public Android.Content.Intent GetRateItPageIntent (String packageName)
			{
				global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain ();

				global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain ();
				Android.Content.Intent __result;

				try {
					__data.WriteInterfaceToken (descriptor);
					__data.WriteString (packageName);
					remote.Transact (IOpenAppstoreStub.TransactionGetRateItPageIntent, __data, __reply, 0);
					__reply.ReadException ();
					__result = Android.Content.Intent.Creator.CreateFromParcel(__reply) as Android.Content.Intent;

				} finally {
					__reply.Recycle ();
					__data.Recycle ();
				}
				return __result;

			}


			public Android.Content.Intent GetSameDeveloperPageIntent (String packageName)
			{
				global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain ();

				global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain ();
				Android.Content.Intent __result;

				try {
					__data.WriteInterfaceToken (descriptor);
					__data.WriteString (packageName);
					remote.Transact (IOpenAppstoreStub.TransactionGetSameDeveloperPageIntent, __data, __reply, 0);
					__reply.ReadException ();
					__result = Android.Content.Intent.Creator.CreateFromParcel(__reply) as Android.Content.Intent;

				} finally {
					__reply.Recycle ();
					__data.Recycle ();
				}
				return __result;

			}


			public bool AreOutsideLinksAllowed ()
			{
				global::Android.OS.Parcel __data = global::Android.OS.Parcel.Obtain ();

				global::Android.OS.Parcel __reply = global::Android.OS.Parcel.Obtain ();
				bool __result;

				try {
					__data.WriteInterfaceToken (descriptor);
					remote.Transact (IOpenAppstoreStub.TransactionAreOutsideLinksAllowed, __data, __reply, 0);
					__reply.ReadException ();
					__result = __reply.ReadInt () != 0;

				} finally {
					__reply.Recycle ();
					__data.Recycle ();
				}
				return __result;

			}


		}

		internal const int TransactionGetAppstoreName = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 0;

		internal const int TransactionIsPackageInstaller = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 1;

		internal const int TransactionIsBillingAvailable = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 2;

		internal const int TransactionGetPackageVersion = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 3;

		internal const int TransactionGetBillingServiceIntent = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 4;

		internal const int TransactionGetProductPageIntent = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 5;

		internal const int TransactionGetRateItPageIntent = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 6;

		internal const int TransactionGetSameDeveloperPageIntent = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 7;

		internal const int TransactionAreOutsideLinksAllowed = global::Android.OS.Binder.InterfaceConsts.FirstCallTransaction + 8;

		public abstract String GetAppstoreName ();

		public abstract bool IsPackageInstaller (String packageName);

		public abstract bool IsBillingAvailable (String packageName);

		public abstract int GetPackageVersion (String packageName);

		public abstract Android.Content.Intent GetBillingServiceIntent ();

		public abstract Android.Content.Intent GetProductPageIntent (String packageName);

		public abstract Android.Content.Intent GetRateItPageIntent (String packageName);

		public abstract Android.Content.Intent GetSameDeveloperPageIntent (String packageName);

		public abstract bool AreOutsideLinksAllowed ();

	}
}
