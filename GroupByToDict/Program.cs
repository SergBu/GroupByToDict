// See https://aka.ms/new-console-template for more information

//тянем тс из бд
using GroupByToDict;

var allTerminalTimeslotVehiclesInTerminalByDate = new List<TerminalTimeslotVehicle>
{

};

int[] allRestrictionsByTerminalAndDateIds = new int[3]{ 11, 12, 13 };

var vehiclesInTerminalByDateWithoutQupta = (from a in allTerminalTimeslotVehiclesInTerminalByDate
                                            where a.Deleted == null ? !allRestrictionsByTerminalAndDateIds.Intersect(a.RestrictionIds).Any() : !allRestrictionsByTerminalAndDateIds.Intersect(a.RestrictionsIdsInfo).Any()
                                            select a).ToList();

var allVehiclesGroupByCrop = vehiclesInTerminalByDateWithoutQupta
    .GroupBy(x => new
    {
        x.CropId,
        combination = x.CombinationId
    }).ToDictionary(x => x.Key, x => x.ToList());

foreach (var vehiclesWithCrop in allVehiclesGroupByCrop)
{

    var vehiclesWithoutQuota = new List<int>();

    if (vehiclesWithoutQuota.Any())
    {
        var newVehiclesWithoutQuotasCropModelList = new
        {
            CropId = vehiclesWithCrop.Key.CropId ?? 0,
            CombinationId = vehiclesWithCrop.Key.combination,
            VehiclesWithoutQuota = vehiclesWithoutQuota
        };
    }
}
