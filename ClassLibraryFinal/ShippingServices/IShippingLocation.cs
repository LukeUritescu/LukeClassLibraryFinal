namespace ClassLibraryFinal
{
    public interface IShippingLocation
    {
        uint StartZipCode { get; set; }
        uint DestinationZipCode { get; set; }
    }
}