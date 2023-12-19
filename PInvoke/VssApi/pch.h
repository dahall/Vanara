// pch.h: This is a precompiled header file.
// Files listed below are compiled only once, improving build performance for future builds.
// This also affects IntelliSense performance, including code completion and many code browsing features.
// However, files listed here are ALL re-compiled if any one of them is updated between builds.
// Do not add files here that you will be updating frequently as this negates the performance advantage.

#ifndef PCH_H
#define PCH_H

// add headers that you want to pre-compile here
#define WINVER 0x0502
#define _AFXDLL
#include <windows.h>
#include <comdef.h>
#include <vss.h>
#include <vswriter.h>
#include <vsbackup.h>
#include "SafePtr.h"
#include "BaseWrapper.h"
#include "Utils.h"
#include "Macros.h"

//#using <Vanara.Core.dll>
//#using <Vanara.PInvoke.Shared.dll>
//#using <Vanara.PInvoke.VssApiMgd.dll>

#endif //PCH_H
