namespace Applications.DAL.Base.Mappers
{
    public interface IBaseMapper<TFirstObject, TSecondObject>
    {
        TFirstObject? Map(TSecondObject? inOnject);
        TSecondObject? Map(TFirstObject? inOnject);
    }
}