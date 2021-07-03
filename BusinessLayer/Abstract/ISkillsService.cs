using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkillsService
    {
        List<Skills> GetList();
        void SkillsAddBL(Skills skills);
        Skills GetByIDBL(int id);
        void SkillsDelete(Skills skills);
        void SkillsUpdate(Skills skills);
    }
}
