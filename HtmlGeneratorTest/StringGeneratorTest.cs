using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlGenerator.StringGenerator;
using HtmlGenerator.Tags;
using HtmlGenerator.TableTags;

namespace HtmlGeneratorTest
{
    [TestClass]
    public class StringGeneratorTest
    {
        private HtmlStringGenerator Generator;

        public StringGeneratorTest()
        {
            Generator = new HtmlStringGenerator(); 
        }

        [TestMethod]
        public void TestLabelToHtmlString()
        {
            Label lLabel = new Label();
            lLabel.Name = "lblNome";
            lLabel.Id = "lblNome";
            lLabel.Text = "Nome";
            lLabel.For = "Nome";
            string lHtml = Generator.ToHtmlString(lLabel);
            Assert.AreEqual<string>("<label  for=\"Nome\" id=\"lblNome\" name=\"lblNome\">Nome</label>", lHtml);
        }

        [TestMethod]
        public void TestHyperLinkToHtmlString()
        {
            HyperLink lLink = new HyperLink();
            lLink.Name = "linkw3";
            lLink.Id = "linkw3";
            lLink.Text = "W3 Schools.com";
            lLink.Class = "btn btn-info";
            lLink.Url = "http://www.w3schools.com/";
            string lHtml = Generator.ToHtmlString(lLink);
            Assert.AreEqual<string>("<a  href=\"http://www.w3schools.com/\" id=\"linkw3\" name=\"linkw3\" class=\"btn btn-info\">W3 Schools.com</a>", lHtml);
        }

    [TestMethod]
        public void TestSpanToHtmlString()
        {
            Span lSpan = new Span();
            lSpan.Name = "spn";
            lSpan.Id = "spn";
            lSpan.Text = "Nome";
            string lHtml = Generator.ToHtmlString(lSpan);
            Assert.AreEqual<string>("<span  id=\"spn\" name=\"spn\">Nome</span>", lHtml);
        }

        [TestMethod]
        public void TestButtonToHtmlString()
        {
            Button lButton = new Button();
            lButton.Name = "btnCancelar";
            lButton.Id = "btnCancelar";
            lButton.Text = "Cancelar";
            lButton.Class = "btn btn-info";
            string lHtml = Generator.ToHtmlString(lButton);
            Assert.AreEqual<string>("<button  type=\"button\" id=\"btnCancelar\" name=\"btnCancelar\" class=\"btn btn-info\">Cancelar</button>", lHtml);
        }

        [TestMethod]
        public void TestButtonWithTagedToHtmlString()
        {
            Button lButton = new Button();
            lButton.Name = "btnCancelar";
            lButton.Id = "btnCancelar";
            lButton.Text = "Cancelar";
            lButton.Class = "btn btn-info";
            lButton.FormOptions.Action = "noaction";
            string lHtml = Generator.ToHtmlString(lButton);
            Assert.AreEqual<string>("<button  type=\"button\" formaction=\"noaction\" id=\"btnCancelar\" name=\"btnCancelar\" class=\"btn btn-info\">Cancelar</button>", lHtml);
        }


        [TestMethod]
        public void TestDivSingleToHtmlString()
        {
            Div lDiv = new Div();
            lDiv.Name = "dvCancelar";
            lDiv.Id = "dvCancelar";
            lDiv.Text = "Cancelar";
            lDiv.Class = "btn btn-info";
            string lHtml = Generator.ToHtmlString(lDiv);
            Assert.AreEqual<string>("<div  id=\"dvCancelar\" name=\"dvCancelar\" class=\"btn btn-info\">Cancelar</div>", lHtml);
        }

        [TestMethod]
        public void TestDivWithButtonToHtmlString()
        {
            Div lDiv = new Div();
            lDiv.Name = "dvCancelar";
            lDiv.Id = "dvCancelar";
            lDiv.Items.AddItem<Button>(lButton =>
            {
                lButton.Name = "btnCancelar";
                lButton.Id = "btnCancelar";
                lButton.Text = "Cancelar";
                lButton.Class = "btn btn-info";
            });
            string lHtml = Generator.ToHtmlString(lDiv);
            Assert.AreEqual<string>("<div  id=\"dvCancelar\" name=\"dvCancelar\"><button  type=\"button\" id=\"btnCancelar\" name=\"btnCancelar\" class=\"btn btn-info\">Cancelar</button></div>", lHtml);
        }

        [TestMethod]
        public void TestDivWithButtonAndSpanToHtmlString()
        {
            Div lDiv = new Div();
            lDiv.Name = "dvCancelar";
            lDiv.Id = "dvCancelar";
            lDiv.Items.AddItem<Button>(lButton =>
            {
                lButton.Name = "btnCancelar";
                lButton.Id = "btnCancelar";
                lButton.Text = "Cancelar";
                lButton.Class = "btn btn-info";
            });

            lDiv.Items.AddItem<Span>(lSpan =>
            {
                lSpan.Name = "spn";
                lSpan.Id = "spn";
                lSpan.Text = "Nome";
            });
            string lHtml = Generator.ToHtmlString(lDiv);
            Assert.AreEqual<string>("<div  id=\"dvCancelar\" name=\"dvCancelar\"><button  type=\"button\" id=\"btnCancelar\" name=\"btnCancelar\" class=\"btn btn-info\">Cancelar</button><span  id=\"spn\" name=\"spn\">Nome</span></div>", lHtml);
        }

        [TestMethod]
        public void TestNumberToHtmlString()
        {
            Number lNumber = new Number();
            lNumber.Name = "number";
            lNumber.Id = "number";
            lNumber.MinimunValue = "1";
            lNumber.MaximunValue = "10";
            string lHtml = Generator.ToHtmlString(lNumber);
            Assert.AreEqual<string>("<input  max=\"10\" min=\"1\" type=\"number\" id=\"number\" name=\"number\"></input>", lHtml);
        }

        [TestMethod]
        public void TestEmptyTableToHtmlString()
        {
            Table lTable = new Table();
            lTable.Name = "table";
            lTable.Id = "table";
            string lHtml = Generator.ToHtmlString(lTable);
            Assert.AreEqual<string>("<table  id=\"table\" name=\"table\"><thead></thead> <tbody></tbody> <tfoot></tfoot></table>", lHtml);
        }

        [TestMethod]
        public void TestTableWithHeadToHtmlString()
        {
            Table lTable = new Table();
            lTable.Name = "table";
            lTable.Id = "table";
            lTable.Head.AddRow(pRow =>
            {
                pRow.AddCellForText(new string[3] { "Nome", "CPF", "RG" });
            });
            string lHtml = Generator.ToHtmlString(lTable);
            Assert.AreEqual<string>("<table  id=\"table\" name=\"table\"><thead><tr><th>Nome</th><th>CPF</th><th>RG</th></tr></thead> <tbody></tbody> <tfoot></tfoot></table>", lHtml);
        }

        [TestMethod]
        public void TestTableWithBodyToHtmlString()
        {
            Table lTable = new Table();
            lTable.Name = "table";
            lTable.Id = "table";
            lTable.Body.AddRow(pRow =>
            {
                pRow.AddCellForText(new string[3] { "Alexandro Martinelli", "832.917.760-20", "1079852834" });
            });
            string lHtml = Generator.ToHtmlString(lTable);
            Assert.AreEqual<string>("<table  id=\"table\" name=\"table\"><thead></thead> <tbody><tr><td>Alexandro Martinelli</td><td>832.917.760-20</td><td>1079852834</td></tr></tbody> <tfoot></tfoot></table>", lHtml);
        }

        [TestMethod]
        public void TestTableWithFootToHtmlString()
        {
            Table lTable = new Table();
            lTable.Name = "table";
            lTable.Id = "table";
            lTable.Footer.AddRow(pRow =>
            {
                pRow.AddCellForText(new string[3] { "Alexandro Martinelli", "832.917.760-20", "1079852834" });
            });
            string lHtml = Generator.ToHtmlString(lTable);
            Assert.AreEqual<string>("<table  id=\"table\" name=\"table\"><thead></thead> <tbody></tbody> <tfoot><tr><td>Alexandro Martinelli</td><td>832.917.760-20</td><td>1079852834</td></tr></tfoot></table>", lHtml);
        }

        [TestMethod]
        public void TestGridToHtmlString()
        {
            Table lTable = new Table();
            lTable.Name = "table";
            lTable.Id = "table";
            lTable.Head.AddRow(pRow =>
            {
                pRow.AddCellForText(new string[3] { "Nome", "CPF", "RG" });
            });
            lTable.Body.AddRow(pRow =>
            {
                pRow.AddCellForText(new string[3] { "Alexandro Martinelli", "832.917.760-20", "1079852834" });
            });
            lTable.Body.AddRow(pRow =>
            {
                pRow.AddCellForText(new string[3] { "Elisandra Martinelli", "832.917.760-20", "1079852834" });
            });
            string lHtml = Generator.ToHtmlString(lTable);
            Assert.AreEqual<string>("<table  id=\"table\" name=\"table\"><thead><tr><th>Nome</th><th>CPF</th><th>RG</th></tr></thead> <tbody><tr><td>Alexandro Martinelli</td><td>832.917.760-20</td><td>1079852834</td></tr><tr><td>Elisandra Martinelli</td><td>832.917.760-20</td><td>1079852834</td></tr></tbody> <tfoot></tfoot></table>", lHtml);
        }
    }
}