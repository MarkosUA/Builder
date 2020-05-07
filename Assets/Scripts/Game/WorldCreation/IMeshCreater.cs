using System.Collections.Generic;

public interface IMeshCreater
{
    Cell[,] CreateMesh(GameZone gameZone);
}
