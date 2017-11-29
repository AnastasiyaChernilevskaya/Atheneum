using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Atheneum.DataAccess.Models;
using Atheneum.DataAccess.Repositories;

namespace Atheneum.Services
{
    public class PeriodicalService
    {
        private PeriodicalRepository _periodicalRepository;
        public PeriodicalService()
        {
            _periodicalRepository = new PeriodicalRepository();
        }

        public List<Periodical> GetPeriodicals()
        {
            return _periodicalRepository.GetPeriodicals();
        }

        public void CreatePeriodical(Periodical periodical)
        {
            _periodicalRepository.CreatePeriodical(periodical);
        }

        public void UpdatePeriodical(Periodical periodical)
        {
            _periodicalRepository.UpdatePeriodical(periodical);
        }

        public void DestroyPeriodical(string id)
        {
            _periodicalRepository.DestroyPeriodical(id);
        }

        public Periodical GetPeriodical(string id)
        {
            return _periodicalRepository.GetPeriodical(id);
        }

        public List<Periodical> GetCheckedPeriodical()
        {
            return _periodicalRepository.GetCheckedPeriodicals();
        }
    }
}