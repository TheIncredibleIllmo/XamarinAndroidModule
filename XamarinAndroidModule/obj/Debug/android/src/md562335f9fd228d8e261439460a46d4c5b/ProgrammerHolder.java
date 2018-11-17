package md562335f9fd228d8e261439460a46d4c5b;


public class ProgrammerHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("XamarinAndroidModule.Holders.ProgrammerHolder, XamarinAndroidModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ProgrammerHolder.class, __md_methods);
	}


	public ProgrammerHolder ()
	{
		super ();
		if (getClass () == ProgrammerHolder.class)
			mono.android.TypeManager.Activate ("XamarinAndroidModule.Holders.ProgrammerHolder, XamarinAndroidModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
