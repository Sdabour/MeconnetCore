using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.HR.HRBusiness;

[Serializable]
public class SectorSimple
{
	public int ID;

	public string Code;

	public string Name;

	public int Level;

	public int ParentID;

	public int Family;

	private static List<SectorSimple> _SctorLst;

	public static List<SectorSimple> SectorLst
	{
		get
		{
			List<SectorSimple> lstSector = new List<SectorSimple>();
			//if (HttpContext.Current.Session != null && HttpContext.Current.Session["SectorSimpleLst"] != null)
			//{
			//	lstSector = (List<SectorSimple>)HttpContext.Current.Session["SectorSimpleLst"];
			//}
			//else
			{
				SectorCol sectorCol = new SectorCol();
				int num = 0;
				Hashtable hsTemp = new Hashtable();
				SectorSimple sectorSimple = new SectorSimple();
				foreach (SectorBiz item in sectorCol)
				{
					sectorSimple = new SectorSimple
					{
						ID = item.ID,
						Name = item.Name,
						Family = item.FamilyID,
						Level = num,
						ParentID = item.ParentID
					};
					lstSector.Add(sectorSimple);
					hsTemp.Add(item.ID.ToString(), sectorSimple);
					SetChildrenLst(num, item, ref lstSector, ref hsTemp);
				}
				List<SectorSimple> list = new List<SectorSimple>();
				//list = (from SectorBiz objSector in EmployeeSectorAssignmentCol.AssignedSectorCol
				//		where hsTemp[objSector.ID.ToString()] != null
				//		select (SectorSimple)hsTemp[objSector.ID.ToString()]).ToList();
				hsTemp = new Hashtable();
				List<SectorSimple> lstSector2 = new List<SectorSimple>();
				foreach (SectorSimple item2 in list)
				{
					if (item2 != null && item2.ID != 0 && hsTemp[item2.ID.ToString()] == null)
					{
						hsTemp.Add(item2.ID.ToString(), item2);
						lstSector2.Add(item2);
						SetChildrenLst(item2, lstSector, ref hsTemp, ref lstSector2);
						SetParentLst(item2, lstSector, ref hsTemp, ref lstSector2);
					}
				}
				lstSector = lstSector2;
				//HttpContext.Current.Session["SectorSimpleLst"] = lstSector;
			}
			return lstSector;
		}
	}

	private static void SetChildrenLst(int intBaseLevel, SectorBiz objSectorBiz, ref List<SectorSimple> lstSector, ref Hashtable hsTemp)
	{
		int num = intBaseLevel + 1;
		foreach (SectorBiz child in objSectorBiz.Children)
		{
			SectorSimple sectorSimple = new SectorSimple
			{
				ID = child.ID,
				Name = child.Name,
				Family = child.FamilyID,
				Level = num,
				ParentID = child.ParentID
			};
			lstSector.Add(sectorSimple);
			if (hsTemp[sectorSimple.ID.ToString()] == null)
			{
				hsTemp.Add(sectorSimple.ID.ToString(), sectorSimple);
			}
			SetChildrenLst(num, child, ref lstSector, ref hsTemp);
		}
	}

	private static void SetParentLst(SectorSimple objSectorBiz, List<SectorSimple> objMainLst, ref Hashtable hsSector, ref List<SectorSimple> lstSector)
	{
		List<SectorSimple> list = objMainLst.Where((SectorSimple objBiz) => objBiz.ID == objSectorBiz.ParentID && objBiz.ID != objSectorBiz.ID).ToList();
		foreach (SectorSimple item in list)
		{
			if (hsSector[item.ID.ToString()] == null)
			{
				hsSector.Add(item.ID.ToString(), item.ID);
				lstSector.Add(item);
				SetParentLst(item, objMainLst, ref hsSector, ref lstSector);
			}
		}
	}

	private static void SetChildrenLst(SectorSimple objSectorBiz, List<SectorSimple> objMainLst, ref Hashtable hsSector, ref List<SectorSimple> lstSector)
	{
		List<SectorSimple> list = objMainLst.Where((SectorSimple objBiz) => objBiz.ParentID == objSectorBiz.ID && objBiz.ID != objSectorBiz.ID).ToList();
		foreach (SectorSimple item in list)
		{
			if (hsSector[item.ID.ToString()] == null)
			{
				hsSector.Add(item.ID.ToString(), item.ID);
				lstSector.Add(item);
				SetChildrenLst(item, objMainLst, ref hsSector, ref lstSector);
			}
		}
	}

	public static List<SectorSimple> GetList(SectorSimple objSectorBiz)
	{
		List<SectorSimple> lstSector = new List<SectorSimple>();
		lstSector.Add(objSectorBiz);
		Hashtable hsSector = new Hashtable();
		hsSector.Add(objSectorBiz.ID.ToString(), objSectorBiz);
		SetChildrenLst(objSectorBiz, SectorLst, ref hsSector, ref lstSector);
		return lstSector;
	}
}
