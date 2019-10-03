using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ICandidateRepo
    {
        Task<IEnumerable<AllCandidates>> GetAllCandidates();
        Task<CandidateDetails> GetCandidateDetails(int ID);
        Task<bool> CreateCandidate(CreateCandidate candidate);
        Task<bool> UpdateCandidate(CreateCandidate candidate);
        Task<bool> ScheduleCandidateInterview(ScheduleInterview interview);
    }
}
