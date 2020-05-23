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

        public string HtmlDoc { get => htmlDoc; private set => htmlDoc = value; }

        /// <summary>
        /// Создает HTML документ с пустым тегом <body></body>, стилями и скриптом MathJax.
        /// </summary>
        private void EmptyDoc()
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
                    "\t<script>" + Environment.NewLine +
                        "\t\tfunction hideAnswers() {" + Environment.NewLine +
                            "\t\t\tvar answers = document.getElementsByClassName('taskAnswer');" + Environment.NewLine +

                            "\t\t\tif (document.getElementById('cb').checked == false) {" + Environment.NewLine +
                                    "\t\t\t\tfor (let i = 0; i < answers.length; i++)" + Environment.NewLine +
                                    "\t\t\t\t{" + Environment.NewLine +
                                        "\t\t\t\t\tanswers[i].style.display = \"none\";" + Environment.NewLine +
                                    "\t\t\t\t}" + Environment.NewLine +
                            "\t\t\t} else {" + Environment.NewLine +
                                "\t\t\t\tfor (let i = 0; i < answers.length; i++)" + Environment.NewLine +
                                "\t\t\t\t{" + Environment.NewLine +
                                    "\t\t\t\t\tanswers[i].style.display = \"block\";" + Environment.NewLine +
                                "\t\t\t\t}" + Environment.NewLine +
                            "\t\t\t}" + Environment.NewLine +
                        "\t\t}" + Environment.NewLine +
                    "\t</script>" + Environment.NewLine +
                    "\t<style>" + Environment.NewLine +
                        "\t\tbody {" + Environment.NewLine +
                            "\t\t\tfont-size: 14px;" + Environment.NewLine +
                            "\t\t\tfont-family: 'Times New Roman', Times, serif;" + Environment.NewLine +
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
                        "\t\t.checkbox_wrapper {" + Environment.NewLine +
                            "\t\t\tmargin: 15px 0;" + Environment.NewLine +
                            "\t\t\tdisplay: flex;" + Environment.NewLine +
                            "\t\t\talign-items: center;" + Environment.NewLine +
                        "\t\t}" + Environment.NewLine +
                        Environment.NewLine +
                        "\t\t.taskVariant {" + Environment.NewLine +
                            "\t\t\tpadding-bottom: 10px;" + Environment.NewLine +
                            "\t\t\tmargin: 0 auto;" + Environment.NewLine +
                            "\t\t\tfont-size: 20px;" + Environment.NewLine +
                            "\t\t\tfont-weight: bold;" + Environment.NewLine +
                        "\t\t}" + Environment.NewLine +
                        Environment.NewLine +
                        "\t\t.taskExpression { margin-bottom: 10px; }" + Environment.NewLine +
                        Environment.NewLine +
                        "\t\t.taskAnswer { margin-bottom: 15px; display: none; }" + Environment.NewLine +
                        Environment.NewLine +
                        "\t\t.info_wrapper {" + Environment.NewLine +
                            "\t\t\tdisplay: flex;" + Environment.NewLine +
                            "\t\t\tjustify-content: space-evenly;" + Environment.NewLine +
                            "\t\t\talign-items: center;" + Environment.NewLine +
                            "\t\t\tfont-size: 16px;" + Environment.NewLine +
                        "\t\t}" + Environment.NewLine +
                        Environment.NewLine +
                        "\t\t.seed {" + Environment.NewLine +
                            "\t\t\tpadding: 2px;" + Environment.NewLine +
                            "\t\t\tborder: 1px solid black;" + Environment.NewLine +
                        "\t\t}" + Environment.NewLine +
                        Environment.NewLine +
                        "\t\t@media print { " + Environment.NewLine +
                            "\t\t\t.task_wrapper { page-break-inside: avoid; }" + Environment.NewLine +
                            "\t\t\t.checkbox_wrapper { display: none; }" + Environment.NewLine +
                            "\t\t\t.info_wrapper { display: none; }" + Environment.NewLine +
                        "\t\t}" + Environment.NewLine +
                    "\t</style>" + Environment.NewLine +
                "</head>" + Environment.NewLine +
                "<body>" + Environment.NewLine +
                    "\t<div class=\"info_wrapper\">" + Environment.NewLine +
                        "\t\t<div class=\"checkbox_wrapper\">" + Environment.NewLine +
                            "\t\t\t<input type=\"checkbox\" onclick=\"hideAnswers()\" id=\"cb\" name=\"cb\">" + Environment.NewLine +
                            "\t\t\t<label for=\"cb\">Показать ответы</label>" + Environment.NewLine +
                        "\t\t</div>" + Environment.NewLine +
                        "\t\t<div class=\"seed_wrapper\">" + Environment.NewLine +
                            "\t\t\tКлюч генерации: <span class=\"seed\">seedValue</span>" + Environment.NewLine +
                        "\t\t</div>" + Environment.NewLine +
                    "\t</div>" + Environment.NewLine +
                Environment.NewLine +
                "<div class=\"tasks_wrapper\">" + Environment.NewLine +
                "</div>" + Environment.NewLine +
                "</body>" + Environment.NewLine +
                "</html>";
        }

        /// <summary>
        /// Создает новый HTML тэг по заданным характеристикам.
        /// </summary>
        /// <param name="tag">Имя тэга</param>
        /// <param name="className">Имя класса</param>
        /// <param name="content">Содержимое тэка</param>
        /// <returns></returns>
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

        /// <summary>
        /// Добавляет в HTML документ с конца новый тэг по заданным характеристикам.
        /// </summary>
        /// <param name="tag">Имя тэга</param>
        /// <param name="className">Имя класса</param>
        /// <param name="content">Содержимое тэка</param>
        /// <returns></returns>
        public void AddTag(string tag, string className = "", string content = "")
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
        }

        /// <summary>
        /// Сохраняет HTML документ по заданной директории path.
        /// </summary>
        /// <param name="path">Путь, по которому сохранится HTML документ</param>
        public void SaveDoc(string path)
        {
            using (StreamWriter fs = new StreamWriter(new FileStream(path, FileMode.Create), Encoding.Unicode))
            {
                fs.Write(HtmlDoc);
            }
        }

        /// <summary>
        /// Меняет ключ генерации.
        /// </summary>
        /// <param name="newSeed"></param>
        public void ChangeSeed(string newSeed)
        {
            HtmlDoc = HtmlDoc.Replace("seedValue", $"{newSeed}");
        }

        // Конструктор.
        public DummyHTML()
        {
            EmptyDoc();
        }
    }
}
