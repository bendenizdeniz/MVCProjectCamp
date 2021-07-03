using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkillsManager : ISkillsService
    {
        ISkillsDal _skillsDal;

        public SkillsManager(ISkillsDal skillsDal)
        {
            _skillsDal = skillsDal;
        }
        public Skills GetByIDBL(int id)
        {
            return _skillsDal.Get(x => x.ID == id);
        }

        public List<Skills> GetList()
        {
            return _skillsDal.List();
        }

        public void SkillsAddBL(Skills skills)
        {
            _skillsDal.Insert(skills);
        }

        public void SkillsDelete(Skills skills)
        {
            _skillsDal.Delete(skills);
        }

        public void SkillsUpdate(Skills skills)
        {
            _skillsDal.Update(skills);
        }

        public String[] getSkills(Skills skills)
        {
            var value = GetList();
            string[] skillList = GetList()[0].Languages.Split(',');
            return skillList;
        }
    }
}
