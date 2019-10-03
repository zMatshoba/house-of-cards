using Domain.Models;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Domain.Contracts;

namespace Domain.Repos
{
    public class CandidateRepo : ICandidateRepo
    {
        private readonly RecruitmentDBContext _context;

        public CandidateRepo(RecruitmentDBContext recruitmentDBContext)
        {
            this._context = recruitmentDBContext;
        }


        public async Task<IEnumerable<AllCandidates>> GetAllCandidates()
        {
            AllCandidates candidates = null;
            List<AllCandidates> cands = new List<AllCandidates>();
            try
            {
                var result = await (from ca in _context.Candidate
                                    join slc in _context.ShortListedCandidate on ca.CandidateId equals slc.CandidateId
                                    join p in _context.Position on slc.PositionId equals p.PositionId
                                    select new
                                    {
                                        ca.CandidateId,
                                        ca.FirstName,
                                        ca.LastName,
                                        ca.Gender,
                                        p.PositionTitle,
                                        p.PositionId
                                    }).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        candidates = new AllCandidates(item.CandidateId,item.PositionId)
                        {
                            FirstName = item.FirstName.Trim(),
                            LastName = item.LastName.Trim(),
                            Gender = item.Gender.Trim(),
                            PositionTitle = item.PositionTitle.Trim()
                        };
                        cands.Add(candidates);
                    }
                }
            }
            catch (Exception)
            {

            }
            return cands;
        }

        public async Task<CandidateDetails> GetCandidateDetails(int ID)
        {
            CandidateDetails details = null;
            List<CandidateDocuments> documents = new List<CandidateDocuments>();
            CandidateDocuments document = null;

            try
            {
                var result = await (from c in _context.Candidate
                                    join slc in _context.ShortListedCandidate on c.CandidateId equals slc.CandidateId
                                    join p in _context.Position on slc.PositionId equals p.PositionId
                                    join i in _context.Interview on slc.ShortListedCandidateId equals i.ShortlistedCandidateId
                                    where c.CandidateId == ID
                                    select new
                                    {
                                        c.CandidateId,
                                        c.FirstName,
                                        c.LastName,
                                        c.Nationality,
                                        c.Idnumber,
                                        c.Dob,
                                        c.Race,
                                        c.Gender,
                                        c.CurrentSalary,
                                        c.CellPhone,
                                        c.AlterCellPhone,
                                        c.WorkNumber,
                                        c.Email,
                                        c.DecisionStatus,
                                        c.FeedBack,
                                        p.PositionTitle,
                                        p.PositionType,
                                        p.BusinessUnit,
                                        p.Budget,
                                        p.EndDate,
                                        i.InterviewDate,
                                        i.InterviewType,
                                        i.InterviewTime,
                                        i.Location
                                    }).FirstAsync();

                if (result != null)
                {
                        details = new CandidateDetails(result.CandidateId)
                        {
                            FirstName = result.FirstName.Trim(),
                            LastName = result.LastName.Trim(),
                            Gender = result.Gender.Trim(),
                            Nationality = result.Nationality.Trim(),
                            Idnumber = result.Idnumber.Trim(),
                            Dob = result.Dob,
                            Race = result.Race.Trim(),
                            CurrentSalary = result.CurrentSalary,
                            CellPhone = result.CellPhone.Trim(),
                            AlterCellPhone = result.AlterCellPhone.Trim(),
                            WorkNumber = result.WorkNumber.Trim(),
                            Email = result.Email.Trim(),
                            FeedBack = result.FeedBack.Trim(),
                            DecisionStatus = result.DecisionStatus.Trim(),
                            InterviewDate = result.InterviewDate,
                            InterviewType = result.InterviewType.Trim(),
                            Location = result.Location.Trim(),
                            InterviewTime = result.InterviewTime,
                            PositionTitle = result.PositionTitle.Trim(),
                            PositionType = result.PositionType.Trim(),
                            Budget = result.Budget,
                            EndDate = result.EndDate
                        };

                        var docs = (from d in _context.Document
                                    where d.CandidateId == ID
                                    select new
                                    {
                                        d.DocumentId,
                                        d.DocumentName,
                                        d.Document1,
                                        d.TestMark,
                                        d.TestType,
                                        d.Date
                                    }).ToList();
                        foreach (var item in docs)
                        {
                            document = new CandidateDocuments()
                            {
                                DocumentName = item.DocumentName.Trim(),
                                Document1 = item.Document1,
                                TestType = item.TestType,
                                TestMark = item.TestMark,
                                Date = item.Date,
                            };
                            documents.Add(document);
                        }
                        details.Documents = documents;
                }
            }
            catch (Exception)
            {

            }
            return details;
        }

        //first create the candidate and there after we can call the LinkCandidateToPosition Method 
        public async Task<bool> CreateCandidate(CreateCandidate candidate)
        {
            bool result = false;
            Candidate details = null;
            try
            {
                if (candidate != null)
                {
                    details = new Candidate()
                    {
                        ConsultantId = candidate.ConsultantId,
                        DecisionStatus = candidate.DecisionStatus,
                        FirstName = candidate.FirstName,
                        LastName = candidate.LastName,
                        Nationality = candidate.Nationality,
                        Idnumber = candidate.Idnumber,
                        Dob = candidate.Dob,
                        Race = candidate.Race,
                        Gender = candidate.Gender,
                        CurrentSalary = candidate.CurrentSalary,
                        CellPhone = candidate.CellPhone,
                        AlterCellPhone = candidate.AlterCellPhone,
                        WorkNumber = candidate.WorkNumber,
                        Email = candidate.Email,
                        FeedBack = candidate.FeedBack
                    };
                    _context.Candidate.Add(details);
                    await _context.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }


        public async Task<bool> UpdateCandidate (CreateCandidate candidate)
        {
            bool result = false;
            try
            {
                var details = await _context.Candidate.FindAsync(candidate.CandidateId);
                if(details != null && candidate != null)
                {
                    details.FirstName = candidate.FirstName;
                    details.LastName = candidate.LastName;
                    details.Nationality = candidate.Nationality;
                    details.Idnumber = candidate.Idnumber;
                    details.Dob = candidate.Dob;
                    details.Race = candidate.Race;
                    details.Gender = candidate.Gender;
                    details.CurrentSalary = candidate.CurrentSalary;
                    details.CellPhone = candidate.CellPhone;
                    details.AlterCellPhone = candidate.AlterCellPhone;
                    details.WorkNumber = candidate.WorkNumber;
                    details.Email = candidate.Email;

                    _context.Candidate.Update(details);
                    await _context.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }


        public async Task<bool> LinkCandidateToPosition(ShortListCandidate shortList)
        {
            ShortListedCandidate listedCandidate = null;
            bool result = false;
            try
            {
                if(shortList != null)
                {
                    listedCandidate = new ShortListedCandidate()
                    {
                        CandidateId = shortList.CandidateId,
                        PositionId = shortList.PositionId,
                        Date = shortList.ShortlistedDate
                    };

                    _context.ShortListedCandidate.Add(listedCandidate);
                    await _context.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception)
            {

            }
            return result;
        }


        public async Task<bool> ScheduleCandidateInterview(ScheduleInterview interview)
        {
            Interview candInterview = null;
            bool result = false;
            try
            {
                var query = await (from slc in _context.ShortListedCandidate
                                    where slc.CandidateId == interview.CandidateId
                                    && slc.PositionId == interview.PositionId
                                    select new {
                                        slc.ShortListedCandidateId }).FirstOrDefaultAsync();

                candInterview = new Interview()
                {
                    ShortlistedCandidateId = query.ShortListedCandidateId,
                    InterviewDate = interview.InterviewDate,
                    Location = interview.Location,
                    InterviewType = interview.InterviewType,
                    InterviewTime = interview.InterviewTime
                };

                _context.Interview.Add(candInterview);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
            return result;
        }

        public async Task<int> GetLastAddedCandidate(int Id)
        {
            int CandidateId = 0;
            try
            {
                var query = await (from c in _context.Candidate
                                   where c.ConsultantId == Id
                                   select new {
                                       c.CandidateId }).LastAsync();

                CandidateId = query.CandidateId;
            }
            catch (Exception)
            {

            }
            return CandidateId;
        }
    }
}
