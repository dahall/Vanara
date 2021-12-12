#define DECL_WRAPPER_PROP(prop, rtype) \
  property rtype prop { virtual rtype get(); }

#define DEFINE_WRAPPER_PROPC(prop, rtype, gtype, meth, conv) \
  virtual property rtype prop {\
    rtype get() {\
      gtype v;\
      Utils::ThrowIfFailed(pNative->meth(&v));\
      return conv(v);\
    }\
  }

#define DEFINE_WRAPPER_GS_PROP(prop, rtype, gtype) \
  virtual property rtype prop {\
    rtype get() {\
      gtype v;\
      Utils::ThrowIfFailed(pNative->Get##prop(&v));\
      return static_cast<rtype>(v);\
    }\
    void set(rtype value) {\
      Utils::ThrowIfFailed(pNative->Set##prop(static_cast<gtype>(value)));\
    }\
  }

#define DEFINE_WRAPPER_QI_PROP(prop, rtype, gtype, meth, qitf) \
  virtual property rtype prop {\
    rtype get() {\
      SafeComPtr<qitf*> p = pNative;\
      gtype v;\
      Utils::ThrowIfFailed(p->meth(&v));\
      return static_cast<rtype>(v);\
    }\
  }

#define DEFINE_WRAPPER_PROP(prop, rtype, gtype, meth) \
  DEFINE_WRAPPER_PROPC(prop, rtype, gtype, meth, static_cast<rtype>)

#define DEFINE_WRAPPER_STRING_PROP(prop, meth) \
  virtual property String^ prop {\
    String^ get() {\
      SafeBSTR v;\
      Utils::ThrowIfFailed(pNative->meth(&v));\
      return (String^)v;\
    }\
  }

#define DEFINE_WRAPPER_STRING_QI_PROP(prop, meth, qitf) \
  virtual property String^ prop {\
    String^ get() {\
      SafeComPtr<qitf*> p = pNative;\
      SafeBSTR v;\
      Utils::ThrowIfFailed(p->meth(&v));\
      return (String^)v;\
    }\
  }

#define DEFINE_WRAPPER_STRING_GS_PROP(prop) \
  virtual property String^ prop {\
    String^ get() {\
      SafeBSTR v;\
      Utils::ThrowIfFailed(pNative->Get##prop(&v));\
      return (String^)v;\
    }\
    void set(String^ value) {\
      SafeString v(value);\
      Utils::ThrowIfFailed(pNative->Set##prop(v));\
    }\
  }

#define DEFINE_WRAPPER_STRING_QI_GS_PROP(prop, qitf) \
  virtual property String^ prop {\
    String^ get() {\
      SafeComPtr<qitf*> p = pNative;\
      SafeBSTR v;\
      Utils::ThrowIfFailed(p->Get##prop(&v));\
      return (String^)v;\
    }\
    void set(String^ value) {\
      SafeComPtr<qitf*> p = pNative;\
      SafeString v(value);\
      Utils::ThrowIfFailed(p->Set##prop(v));\
    }\
  }

#define mgd_cast(T, t)   (T^)Marshal::GetObjectForIUnknown(IntPtr((void*)t));
