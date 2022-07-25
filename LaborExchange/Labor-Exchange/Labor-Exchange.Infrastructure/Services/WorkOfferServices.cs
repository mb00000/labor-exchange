using Labor_Exchange.Application.IRepositories;
using Labor_Exchange.Application.IServices;
using Labor_Exchange.Application.Paging;
using Labor_Exchange.Core.Entities;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace Labor_Exchange.Infrastructure.Services
{
    public class WorkOfferServices : IWorkOfferServices
    {
        private readonly IRepository<WorkOffer> _workOfferRepository;

        public WorkOfferServices(IRepository<WorkOffer> workOfferRepository)
        {
            this._workOfferRepository = workOfferRepository;
        }
        public async Task AddWorkOffer(WorkOffer workOffer)
        {
            await this._workOfferRepository.AddAsync(workOffer);
        }

        public async Task ChangeStoragedStatus(int id)
        {
            var workOffer = await this._workOfferRepository.GetOneAsync(id);
            workOffer.IsStoraged = !workOffer.IsStoraged;
            workOffer.dateTime = DateTime.Now;
            await this._workOfferRepository.SaveAsync();
        }

        public async Task GenerateWorkOffersPDF(string path, int id)
        {
            var document = new PdfDocument();
            var page = document.Pages.Add();

            var font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            var graphics = page.Graphics;

            var workOffer = await this._workOfferRepository.GetOneAsync(id);

            graphics.DrawString($"{workOffer.Company} company is looking for a {workOffer.Position}!", font, PdfBrushes.Black, new PointF(140, 30));
            graphics.DrawString($"If you are good {workOffer.Position} you can try to get work in our company.", font, PdfBrushes.Black, new PointF(100, 60));
            graphics.DrawString($"We can offer you {workOffer.Conditions}", font, PdfBrushes.Black, new PointF(90, 90));
            graphics.DrawString($"Also you will be provided {workOffer.Housing} oportunities for living", font, PdfBrushes.Black, new PointF(90, 120));
            graphics.DrawString($"We require {workOffer.Requirements} to our future workers.", font, PdfBrushes.Black, new PointF(170, 150));
            graphics.DrawString($"Looking forward to your offers!", font, PdfBrushes.Black, new PointF(170, 180));
            graphics.DrawString($"If you need work and you suit us, you can contact us.", font, PdfBrushes.Black, new PointF(110, 210));
            graphics.DrawString($"Tel: {workOffer.Contacts}", font, PdfBrushes.Black, new PointF(210, 240));
            using (var fs = File.Create(path))
            {
                document.Save(fs);
            }
        }

        public async Task<WorkOffer> GetOneAsync(int id)
        {
            return await this._workOfferRepository.GetOneAsync(id);
        }

        public async Task<int> GetWorkOffersCount()
        {
            return await this._workOfferRepository.GetCountEntities();
        }

        public async Task<PagedList<WorkOffer>> GetWorkOffersPageAsync(PageParameters pageParameters, bool predicate)
        {
            return await this._workOfferRepository.GetPageAsync(pageParameters, i => i.IsStoraged == predicate);
        }

        public async Task<PagedList<WorkOffer>> GetWorkOffersPageAsync(PageParameters pageParameters, string filter, int option)
        {
            if(option == 1)
            {
                return await this._workOfferRepository.GetPageAsync(pageParameters, i => i.Position.StartsWith(filter));

            }
            else
            {
                var list = await this._workOfferRepository.GetPageAsync(pageParameters, i => i.Position == filter);
                foreach (var item in list)
                {
                    if(item.IsStoraged == true)
                    {
                        list.Remove(item);
                    }
                }
                return list;
            }
        }

        public async Task RemoveByIdAsync(int Id)
        {
            var workOffer = await this._workOfferRepository.GetOneAsync(Id);
            await this._workOfferRepository.DeleteAsync(workOffer);
        }

        public async Task SaveChangesAsync()
        {
            await this._workOfferRepository.SaveAsync();
        }
    }
}
