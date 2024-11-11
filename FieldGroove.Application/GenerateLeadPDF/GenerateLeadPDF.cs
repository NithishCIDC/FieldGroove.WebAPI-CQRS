using FieldGroove.Application.EmailService;
using FieldGroove.Domain.Interfaces;
using FieldGroove.Domain.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FieldGroove.Application.GenerateLeadPDF
{
    public class GenerateLeadPDF(IEmailSender emailSender)
    {

        public static void LeadPDF(LeadsModel model)
        {
            using var Lead = new MemoryStream();
            var document = new Document();
            PdfWriter.GetInstance(document, Lead);
            document.Open();

            document.Add(new Paragraph("Lead Details"));
            document.Add(new Paragraph($"Id: {model.Id}"));
            document.Add(new Paragraph($"ProjectName: {model.ProjectName}"));
            document.Add(new Paragraph($"Status: {model.Status}"));
            document.Add(new Paragraph($"Added: {model.Added}"));
            document.Add(new Paragraph($"Type: {model.Type}"));
            document.Add(new Paragraph($"Contact: {model.Contact}"));
            document.Add(new Paragraph($"Action: {model.Action}"));
            document.Add(new Paragraph($"Assignee: {model.Assignee}"));
            document.Add(new Paragraph($"BidDate: {model.BidDate}"));

            document.Close();
            emailSender.EmailSendAsync();
        }
    }
}
