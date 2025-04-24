#pragma warning disable CA1050,CS0162,CS01696
// ReSharper disable UnusedMember.Global,UnusedMemberInSuper.Global,HeuristicUnreachableCode,ArrangeTypeModifiers,ArrangeTypeMemberModifiers

using Pure.DI;
using static Pure.DI.Lifetime;

var composition = new Composition();
var root = composition.Root;
root.Run();

return;

DI.Setup(nameof(Composition))
    .Bind().As(Singleton).To<Random>()
    .Bind().To((Random random) => (State)random.Next(2))
    .Bind().To<ShroedingersCat>()
    .Bind().To<CardboardBox<TT>>()
    // The only composition root for the app.
    .Root<Program>("Root");

partial class Program(IBox<ICat> box)
{
    void Run() => Console.WriteLine(box);
}

interface IBox<out T>
{
    T Content { get; }
}

interface ICat
{
    State State { get; }
}

enum State  { Alive, Dead }

record CardboardBox<T>(T Content) : IBox<T>;

class ShroedingersCat(Lazy<State> superposition) : ICat
{
    public State State => superposition.Value;

    public override string ToString() => $"{State} cat";
}