## Assembly report for Vanara.CodeGen
Analyzer, code fixer, and code generator for Vanara assemblies. Current implementations:

* Handle generator from file or attributed structures and classes to ensure consisisent implementation of handles.
* Extension method generator for any method that has an 'object' marshaled as a COM interface with an IID specifier.
* Analyzer to ensure that 'null' or 'default' is not used as a parameter value for a SafeHandle or HANDLE.