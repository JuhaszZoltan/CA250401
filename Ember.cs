class Ember
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override bool Equals(object obj)
    {
        return this.Name == (obj as Ember).Name && this.Age == (obj as Ember).Age;
    }
}
