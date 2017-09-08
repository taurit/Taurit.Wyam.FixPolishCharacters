using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using Wyam.Common.Documents;
using Wyam.Common.Execution;
using Wyam.Common.Modules;

namespace Wyam.FixPolishCharacters
{
    public class FixPolishCharacters : IModule
    {
        public IEnumerable<IDocument> Execute(IReadOnlyList<IDocument> inputs, IExecutionContext context)
        {
            var documents = new List<IDocument>();

            foreach (var input in inputs)
            {
                var contentBefore = new StreamReader(input.GetStream()).ReadToEnd();
                var contentAfter = FixPolishUtfCharacters(contentBefore);
                var modifiedContentAsStream = context.GetContentStream(contentAfter);

                var doc = context.GetDocument(input, modifiedContentAsStream, new Dictionary<string, object>());
                documents.Add(doc);
            }
            
            return documents;
        }

        // useful table: https://pl.wikipedia.org/wiki/Kodowanie_polskich_znak%C3%B3w
        internal string FixPolishUtfCharacters([CanBeNull] string contentBefore)
        {
            if (contentBefore == null) return null;

            return contentBefore
                .ReplaceCaseInsensitive("&#x104;", "Ą")
                .ReplaceCaseInsensitive("&#x106;", "Ć")
                .ReplaceCaseInsensitive("&#x118;", "Ę")
                .ReplaceCaseInsensitive("&#x141;", "Ł")
                .ReplaceCaseInsensitive("&#x143;", "Ń")
                .ReplaceCaseInsensitive("&#xD3;", "Ó")
                .ReplaceCaseInsensitive("&#x15A;", "Ś")
                .ReplaceCaseInsensitive("&#x179;", "Ź")
                .ReplaceCaseInsensitive("&#x17B;", "Ż")
                .ReplaceCaseInsensitive("&#x105;", "ą")
                .ReplaceCaseInsensitive("&#x107;", "ć")
                .ReplaceCaseInsensitive("&#x119;", "ę")
                .ReplaceCaseInsensitive("&#x142;", "ł")
                .ReplaceCaseInsensitive("&#x144;", "ń")
                .ReplaceCaseInsensitive("&#xF3;", "ó")
                .ReplaceCaseInsensitive("&#x15B;", "ś")
                .ReplaceCaseInsensitive("&#x17A;", "ź")
                .ReplaceCaseInsensitive("&#x17C;", "ż");
        }
    }
}