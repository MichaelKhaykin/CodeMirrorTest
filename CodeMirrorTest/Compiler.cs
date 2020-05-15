using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CodeMirrorTest
{
    public class DiagonisticInfo
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }
        public DiagonisticInfo(int row, int column, string text, string type)
        {
            Row = row;
            Column = column;
            Text = text;
            Type = type;
        }
    }
    public class Compiler
    {
        public bool IsCompiled { get; private set; }
        public List<DiagonisticInfo> Compile(string code)
        {
            List<DiagonisticInfo> info = new List<DiagonisticInfo>();

            var syntaxTree = CSharpSyntaxTree.ParseText(code);

            var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);
            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            };

            var assemblyName = "GMRAssembly";
            var compiledCode = CSharpCompilation.Create(assemblyName)
                                .WithOptions(options)
                                .AddReferences(references)
                                .AddSyntaxTrees(syntaxTree);

            var diagnostics = compiledCode.GetDiagnostics();

            IsCompiled = !diagnostics.Any(k => k.WarningLevel == 0);

            foreach (var diagnostic in diagnostics)
            {
                info.Add(new DiagonisticInfo(diagnostic.Location.GetLineSpan().StartLinePosition.Line,
                                             diagnostic.Location.GetLineSpan().StartLinePosition.Character,
                                             diagnostic.GetMessage(),
                                             diagnostic.WarningLevel == 0 ? "error" : "warning"));
            }

            return info;
        }
        
        public void CompileAndBuild(string code)
        {
            List<DiagonisticInfo> info = new List<DiagonisticInfo>();

            var syntaxTree = CSharpSyntaxTree.ParseText(code);

            var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);
            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            };

            var assemblyName = "GMRHackers";
            var compiledCode = CSharpCompilation.Create(assemblyName)
                                .WithOptions(options)
                                .AddReferences(references)
                                .AddSyntaxTrees(syntaxTree);

            var diagnostics = compiledCode.GetDiagnostics();

            IsCompiled = !diagnostics.Any(k => k.WarningLevel == 0);

            foreach (var diagnostic in diagnostics)
            {
                info.Add(new DiagonisticInfo(diagnostic.Location.GetLineSpan().StartLinePosition.Line,
                                             diagnostic.Location.GetLineSpan().StartLinePosition.Character,
                                             diagnostic.GetMessage(),
                                             diagnostic.WarningLevel == 0 ? "error" : "warning"));
            }

            if (!IsCompiled) return;

            using var stream = new MemoryStream();
            compiledCode.Emit(stream);
            var assembly = Assembly.Load(stream.ToArray());

            Type type = assembly.GetType($"{assemblyName}.Program");
            object obj = Activator.CreateInstance(type);

            try
            {
                MethodInfo result = type.GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Static);
                object addition = result.Invoke(obj, new object[] { 5, 5 });
            }
            catch (TargetInvocationException e)
            {
                Console.WriteLine($"\nRuntime error: {e.InnerException.Message}\n\t{e.InnerException.StackTrace}\n");
            }
        }
    }
}
