using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Entity.Abstract;
using KonusarakOgren.Entity.Entities;
using KonusarakOgren.Model.Exam.Request;
using KonusarakOgren.Model.Exam.Response;
using KonusarakOgren.ModelMapper.Exam;
using KonusarakOgren.Service.Abstract;

namespace KonusarakOgren.Business.Concrete
{
    public partial class ExamBusiness : IExamBusiness
    {
        private readonly IExamService _examService;

        public ExamBusiness(IExamService examService)
        {
            _examService = examService;
        }

        public ExamCreateResponseModel CreateExam(ExamCreateRequestModel model)
        {
            CreateExamValidation(model);

            var createExam = model.MapToDto();
            var result = _examService.CreateExam(createExam);
            
            return new ExamCreateResponseModel() {Success = result.Success};
        }

        public ExamDeleteResponseModel DeleteExam(int examId)
        {
            DeleteExamValidation(examId);
            var result = _examService.DeleteExam(examId);
            return new ExamDeleteResponseModel() {Success = result.Success};
        }

        public ExamGetAllResponseModel GetAllExams()
        {
            var exams = _examService.GetAll();
            return exams.MapToModel();
        }

        public ExamGetExamResponseModel GetExam(int examId)
        {
            var exam = _examService.GetExam(examId);
            return exam.Data.MapToModel();
        }


        public async Task<ScrapeWiredComResponseModel> ScrapeWiredCom()
        {
            const string url = "https://www.wired.com";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            //Anasayfadan linkleri toplanıyor.

            var firstComponent = htmlDocument.DocumentNode
                .Descendants("div").FirstOrDefault(x => x.GetAttributeValue("class", "")
                    .Equals("cards-component"));


            var articles = firstComponent?.Descendants("div")
                .Where(x => x.GetAttributeValue("class", "")
                    .Contains("card-component")).ToList();
            var links = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                var link = articles?[i].Descendants("a").FirstOrDefault()?.GetAttributeValue("href", "");
                var insert = link?.Insert(0, "https://www.wired.com");
                links.Add(insert);
            }

            // Makale linkleri toplandı.
            var titleList = new List<string>();
            var contentList = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                var htmlFor = await httpClient.GetStringAsync(links[i]);

                htmlDocument.LoadHtml(htmlFor);


                htmlDocument.DocumentNode.SelectNodes("//style|//script").ToList().ForEach(n => n.Remove());

                var title = htmlDocument.DocumentNode
                    .SelectSingleNode(".//h1[@class='content-header__row content-header__hed']")
                    .InnerText;
                titleList.Add(title);
                var content = htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(x =>
                        x.GetAttributeValue("class", "")
                            .Equals("grid--item body body__container article__body grid-layout__content"))?
                    .FirstChild
                    .InnerText;
                content += " " + htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(x =>
                        x.GetAttributeValue("class", "")
                            .Equals("grid--item body body__container article__body grid-layout__content"))?
                    .FirstChild
                    .NextSibling
                    .InnerText;
                content += " " + htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(x =>
                        x.GetAttributeValue("class", "")
                            .Equals("grid--item body body__container article__body grid-layout__content"))?
                    .FirstChild
                    .NextSibling
                    .NextSibling
                    .InnerText;
                string decodedString = System.Web.HttpUtility.HtmlDecode(content);

                //Reklam değeri olan içerikler için:

                if (string.IsNullOrEmpty(content))
                {
                    content = htmlDocument.DocumentNode.Descendants("div")
                        .FirstOrDefault(x =>
                            x.GetAttributeValue("class", "")
                                .Equals("gallery__text-block"))?
                        .InnerText;
                    content += " " + htmlDocument.DocumentNode.Descendants("div")
                        .FirstOrDefault(x =>
                            x.GetAttributeValue("class", "")
                                .Equals("grid--item body body__container article__body grid-layout__content"))?
                        .FirstChild
                        .NextSibling
                        .InnerText;
                    content += " " + htmlDocument.DocumentNode.Descendants("div")
                        .FirstOrDefault(x =>
                            x.GetAttributeValue("class", "")
                                .Equals("grid--item body body__container article__body grid-layout__content"))?
                        .FirstChild
                        .NextSibling
                        .NextSibling
                        .InnerText;
                    decodedString = System.Web.HttpUtility.HtmlDecode(content);
                }

                contentList.Add(decodedString);
            }

            return new ScrapeWiredComResponseModel() {TitleList = titleList, ContentList = contentList};
        }
    }
}