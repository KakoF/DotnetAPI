using Domain.DTO.SimianCalcDTO;
using Domain.Entities;

public static class ExtensionSimianCalcHelpers
{
    public static SimianCalcResponseDTO ToDto(this SimianCalcEntity entity)
    {
        if (entity != null)
        {
            return new SimianCalcResponseDTO(entity.Id, entity.Total, entity.CountIsSimian, entity.CountIsHuman, entity.IsSimianPercent, entity.IsHumanPercent, entity.Ratio);
        }

        return null;
    }

    public static IEnumerable<SimianCalcResponseDTO> ListDTO(this IEnumerable<SimianCalcEntity> entity)
    {
        foreach (var item in entity)
        {
            yield return ToDto(item);
        }
    }
}