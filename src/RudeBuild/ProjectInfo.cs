﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RudeBuild
{
    public class ProjectInfo
    {
        public SolutionInfo Solution { get; private set; }
        public string FileName { get; private set; }
        public string Name { get; private set; }
        public IList<string> CppFileNames { get; private set; }
        public IList<string> IncludeFileNames { get; private set; }
        public string PrecompiledHeaderName { get; private set; }       // Name of precompiled header without path.
        public string PrecompiledHeaderFileName { get; private set; }   // Project-relative path of precompiled header as parsed out of the project file.

        public ProjectInfo(SolutionInfo solution, string fileName, IList<string> cppFileNames, IList<string> includeFileNames, string precompiledHeaderName)
        {
            Solution = solution;
            FileName = fileName;
            CppFileNames = cppFileNames;
            IncludeFileNames = includeFileNames;
            Name = Path.GetFileNameWithoutExtension(fileName);
            PrecompiledHeaderName = ExpandMacros(precompiledHeaderName);
            PrecompiledHeaderFileName = GetPrecompiledHeaderFileName(PrecompiledHeaderName, IncludeFileNames);
        }

        private static string GetPrecompiledHeaderFileName(string precompiledHeaderName, IEnumerable<string> includeFileNames)
        {
            var result = from includeFileName in includeFileNames
                         let nameWithoutPath = Path.GetFileName(includeFileName)
                         where string.Compare(includeFileName, precompiledHeaderName, StringComparison.OrdinalIgnoreCase) == 0 || 
                            (!string.IsNullOrEmpty(nameWithoutPath) && string.Compare(nameWithoutPath, precompiledHeaderName, StringComparison.OrdinalIgnoreCase) == 0)
                         select includeFileName;
            return result.SingleOrDefault();
        }

        public string ExpandMacros(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            string solutionPath = Solution.FilePath;
            string projectPath = Path.GetFullPath(FileName);

            value = value.Replace("$(SolutionName)", Solution.Name);
            value = value.Replace("$(SolutionPath)", solutionPath);
            value = value.Replace("$(SolutionFileName)", Path.GetFileName(solutionPath));
            value = value.Replace("$(SolutionDir)", Path.GetDirectoryName(solutionPath) + Path.DirectorySeparatorChar);
            value = value.Replace("$(SolutionExt)", Path.GetExtension(solutionPath));
            
            value = value.Replace("$(ProjectName)", Name);
            value = value.Replace("$(ProjectPath)", projectPath);
            value = value.Replace("$(ProjectFileName)", Path.GetFileName(projectPath));
            value = value.Replace("$(ProjectDir)", Path.GetDirectoryName(projectPath) + Path.DirectorySeparatorChar);
            value = value.Replace("$(ProjectExt)", Path.GetExtension(projectPath));

            return value;
        }
    }
}
