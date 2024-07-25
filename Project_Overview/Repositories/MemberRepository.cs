using Project_Overview.Classes;
using Project_Overview.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Overview.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private List<Member> members = new List<Member>();

        public void Add(Member member) => members.Add(member);
        public void Update(Member member)
        {
            var existing = GetById(member.Id);
            if (existing != null)
            {
                existing.Name = member.Name;
                existing.BorrowedBooks = member.BorrowedBooks;
            }
        }
        public void Delete(Guid id) => members.RemoveAll(m => m.Id == id);
        public Member GetById(Guid id) => members.FirstOrDefault(m => m.Id == id);
        public List<Member> GetAll() => members;
    }
}
