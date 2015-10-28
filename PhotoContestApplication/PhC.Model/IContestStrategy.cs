namespace PhC.Model
{

    interface IContestStrategy<T>
    {
        int Id { get; set; }
        Contest Contest { get; set; }
        T Type { get; set; }
    }
}
