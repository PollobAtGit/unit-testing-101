﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Service.Interface;

namespace NUnitTest.Fakes
{
    class FakeConfigurationIsEmptyFileReader : IFileReader
    {
        public List<string> GetAllLines(string fileWithOutPath) => new List<string>();
    }

    class FakeDefaultConfigurationFileReader : IFileReader
    {
        public List<string> GetAllLines(string fileWithOutPath) => new List<string>()
        {
            ".slf",
            ".sln"
        };
    }

    class FakeConfigurationFileIsMissingFileReader : IFileReader
    {
        public List<string> GetAllLines(string fileWithOutPath) => throw new FileNotFoundException();
    }

    class FakeConfigurableFileReader : IFileReader
    {
        private readonly Exception _exceptionToThrow;
        private readonly List<string> _allowedExtensions;

        public FakeConfigurableFileReader(Exception exceptionToThrow = null, List<string> allowedExtensions = null)
        {
            _exceptionToThrow = exceptionToThrow;
            _allowedExtensions = allowedExtensions;
        }

        public List<string> GetAllLines(string fileWithOutPath)
        {
            if (_exceptionToThrow != null)
                throw _exceptionToThrow;

            return _allowedExtensions;
        }
    }
}