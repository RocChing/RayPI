﻿using System.Linq;
using RayPI.Domain.Entity;
using RayPI.Domain.IRepository;
using RayPI.Infrastructure.Treasury.Models;

namespace RayPI.Business
{
    public class StudentBusiness
    {
        private IStudentRepository _studentRepository;
        public StudentBusiness(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentEntity GetById(long id)
        {
            return _studentRepository.FindById(id);
        }

        public PageResult<StudentEntity> GetPageList(int pageIndex, int pageSize)
        {
            return _studentRepository.GetPageList<StudentEntity>(pageIndex, pageSize);
        }

        public bool Add(StudentEntity entity)
        {
            _studentRepository.Add(entity);
            return true;
        }

        public bool Update(StudentEntity entity)
        {
            _studentRepository.Update(entity);
            return true;
        }

        public bool Dels(long[] ids)
        {
            _studentRepository.Delete(x => ids.Contains(x.Id));
            return true;
        }

        public StudentEntity GetByName(string name)
        {
            return _studentRepository.GetAllMatching(x => x.Name.Contains(name)).FirstOrDefault();
        }
    }
}
