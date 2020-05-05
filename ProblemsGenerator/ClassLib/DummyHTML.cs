using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class DummyHTML
    {
        private string htmlDoc;

        public string HtmlDoc { get => htmlDoc; set => htmlDoc = value; }

        public void EmptyDoc()
        {
            HtmlDoc =
                "<!DOCTYPE html>" + Environment.NewLine +
                "<html lang=\"ru\">" + Environment.NewLine +
                "<head>" + Environment.NewLine +
                    "\t<meta charset=\"UTF-8\">" + Environment.NewLine +
                    "\t<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" + Environment.NewLine +
                    "\t<title>Document</title>" + Environment.NewLine +
                    "\t<link rel=\"stylesheet\" href=\"styles/styles.css\">" + Environment.NewLine +
                    "\t<script src=\"https://polyfill.io/v3/polyfill.min.js?features=es6\"></script>" + Environment.NewLine +
                    "\t<script id=\"MathJax-script\" async src=\"https://cdn.jsdelivr.net/npm/mathjax@3/es5/tex-mml-chtml.js\"></script>" + Environment.NewLine +
                    "\t<style>" + Environment.NewLine +
                        "\t\tbody {" + Environment.NewLine +
                            "\t\t\tfont - size: 14px;" + Environment.NewLine +
                            "\t\t\tfont - family: 'Times New Roman', Times, serif;" + Environment.NewLine +
                        "\t\t}" + Environment.NewLine +
                        Environment.NewLine +
                        "\t\t.tasks_wrapper {" + Environment.NewLine +
                        	"\t\t\tmargin-left: auto;" + Environment.NewLine +
    		                "\t\t\tmargin-right: auto;" + Environment.NewLine +
                            "\t\t\t/* display: flexbox; */" + Environment.NewLine +
                            "\t\t\tdisplay: flex;" + Environment.NewLine +
			                "\t\t\talign-items: center;" + Environment.NewLine +
			                "\t\t\tjustify-content: center;" + Environment.NewLine +
			                "\t\t\tflex-wrap: wrap;" + Environment.NewLine +
                            "\t\t\talign-items: stretch;" + Environment.NewLine +
		                "\t\t}" + Environment.NewLine +
                        Environment.NewLine +
		                "\t\t.task_wrapper {" + Environment.NewLine +
			                "\t\t\twidth: 25vw;" + Environment.NewLine +
                            "\t\t\tmin-width: 250px;" + Environment.NewLine +
                            "\t\t\tpadding: 10px;" + Environment.NewLine +
			                "\t\t\tborder: dashed 1px grey;" + Environment.NewLine +
                            "\t\t\tdisplay: flex;" + Environment.NewLine +
                            "\t\t\tflex-direction: column;" + Environment.NewLine +
                            "\t\t\t/* flex-grow: 1; */" + Environment.NewLine +
                            "\t\t\toverflow: hidden;" + Environment.NewLine +
                        "\t\t}" + Environment.NewLine +
                        Environment.NewLine +
                        "\t\t.taskVariant {" + Environment.NewLine +
                            "\t\t\tpadding-bottom: 10px;" + Environment.NewLine +
                            "\t\t\tmargin: 0 auto;" + Environment.NewLine +
                            "\t\t\tfont-size: 20px;" + Environment.NewLine +
                            "\t\t\tfont-weight: bold;" + Environment.NewLine +
                        "\t\t}" + Environment.NewLine +
                        Environment.NewLine +
                        "\t\t .taskAnswer { margin-bottom: 10px; }" + Environment.NewLine +
                        Environment.NewLine +
                        "\t\t@media print { .task_wrapper { page -break-inside: avoid; } }" + Environment.NewLine +
                    "\t</style>" + Environment.NewLine +
                "</head>" + Environment.NewLine +
                "<body>" + Environment.NewLine +
                "<div class=\"tasks_wrapper\">" + Environment.NewLine +
                "</div>" + Environment.NewLine +
                "</body>" + Environment.NewLine +
                "</html>";
        }

        public string CreateTag(string tag, string className = "", string content = "")
        {
            string newTag;

            if (className == String.Empty)
            {
                if (content == string.Empty)
                {
                    newTag = $"<{tag}>" + Environment.NewLine +
                             $"</{tag}>" + Environment.NewLine;
                }
                else
                {
                    newTag = $"<{tag}>" + Environment.NewLine +
                             $"\t{content}" + Environment.NewLine +
                             $"</{tag}>" + Environment.NewLine;
                }
            }
            else
            {
                if (content == string.Empty)
                {
                    newTag = $"<{tag} class={className}>" + Environment.NewLine +
                             $"</{tag}>" + Environment.NewLine;
                }
                else
                {
                    newTag = $"<{tag} class={className}>" + Environment.NewLine +
                             $"\t{content}" + Environment.NewLine +
                             $"</{tag}>" + Environment.NewLine;
                }
            }

            return newTag;
        }

        public string AddTag(string tag, string className = "", string content = "")
        {
            string newTag = CreateTag(tag, className, content);

            if (className == String.Empty)
            {
                if (content == string.Empty)
                {
                    HtmlDoc = HtmlDoc.Insert(HtmlDoc.LastIndexOf("</div>"), newTag + Environment.NewLine);
                }
                else
                {
                    HtmlDoc = HtmlDoc.Insert(HtmlDoc.LastIndexOf("</div>"), newTag) + Environment.NewLine;
                }
            }
            else
            {
                if (content == string.Empty)
                {
                    HtmlDoc = HtmlDoc.Insert(HtmlDoc.LastIndexOf("</div>"), newTag + Environment.NewLine);
                }
                else
                {
                    HtmlDoc = HtmlDoc.Insert(HtmlDoc.LastIndexOf("</div>"), newTag + Environment.NewLine);
                }
            }

            Console.WriteLine(HtmlDoc);

            return newTag;
        }

        public void SaveDoc(string path)
        {
            using (StreamWriter fs = new StreamWriter(new FileStream(path, FileMode.Create), Encoding.Unicode))
            {
                try
                {
                    fs.Write(HtmlDoc);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public DummyHTML()
        {
            EmptyDoc();
        }
    }
}
