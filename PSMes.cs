namespace PSMes;

using System;
using System.Management.Automation;
using Mes;

[Cmdlet(VerbsCommon.New, "Mes")]
public class ParseMes : PSCmdlet
{
    [Parameter(Position=0)]
    public string MesText { get; set; }

    protected override void ProcessRecord()
    {
        MesBuilder builder = new MesBuilder(this.MesText ?? "");
        var mesobj = builder.Build();
        WriteObject(mesobj, true);
    }
}

[Cmdlet(VerbsCommon.Get, "MesBuilder")]
public class GetMesBuilder : Cmdlet
{
    [Parameter(Position = 0)]
    public string? MesText { get; set; }

    [Parameter(Position = 1)]
    public string? File { get; set; }



    protected override void ProcessRecord()
    {
        if (File == null)
        {
            MesBuilder builder = new MesBuilder(this.MesText);
            WriteObject(builder, true);

        }
        else
        {
            MesBuilder builder = new MesBuilder(System.IO.File.ReadAllText(File));
            WriteObject(builder, true);
        }
    }
}
