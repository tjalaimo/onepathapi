using onepathapi.Models;

namespace onepathapi.DTOs
{
    public class BaseConditionDTO
    {        
        public int ConditionId { get; set; }   
        public string? ConditionCode { get; set; }        
        public string? ConditionDescription { get; set; }
        public DateTime? OnsetDate { get; set; }

        public BaseConditionDTO() {}

        public BaseConditionDTO(Condition condition)
        {
            ConditionId = condition.ConditionId;
            ConditionCode = condition.ConditionCode;
            ConditionDescription = condition.ConditionDescription;
            OnsetDate = condition.OnsetDate;
        }
    }
}