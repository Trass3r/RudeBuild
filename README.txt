RudeBuild, Version 1.0
----------------------

A bulk/unity C++ build tool for Visual Studio, developed by Martin Ecker.
This is free, open source software under the zlib license.

For more information and latest updates please visit:
http://rudebuild.sourceforge.net

----------------------

RudeBuild is a non-intrusive bulk/unity C++ build tool that seamlessly 
integrates into Visual Studio 2008 and 2010. It can speed up build times 
of large C++ projects by a factor of 5 or more.

RudeBuild comes in two flavors, as a command-line tool that works on
Visual Studio solution files and as a Visual Studio addin complete with
toolbar and menus.

When used as an addin the toolbar acts and looks just like the regular 
build toolbar but behind the scenes a bulk/unity build of C++ projects 
is triggered, automatically combining the .cpp
files into unity files in a cache location and running devenv to
build the modified solution/project. Using RudeBuild in this manner
is transparent to the developer and requires no modification to the
original source code or project files whatsoever given that the codebase
is bulk/unity build-safe. Being bulk/unity-build safe means that
there are no symbols with the same name in two different translation
units. For example, it is invalid to have a static function called GetFileTime
in both File1.cpp and File2.cpp.

The command line version of RudeBuild is useful for automated builds, for
example on build servers. A solution file, build configuration and optionally
a project name must be specified on the command line.

----------------------

RudeBuild is written in C# and requires the .NET framework 3.5 or higher.
It also uses the CommandLineParser library that is available here: http://commandline.codeplex.com/
