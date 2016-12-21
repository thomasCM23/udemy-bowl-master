using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public class ScoreDisplayTest
{
    [Test]
    public void T01_Bowl1()
    {
        int[] rolls = { 1 };
        string rollsString = "1";
        Assert.AreEqual(rollsString, ScoreDisplay.FormateRolls(rolls.ToList()));
    }
    [Test]
    public void T02_BowlStrike()
    {
        int[] rolls = { 10 };
        string rollsString = "X ";
        Assert.AreEqual(rollsString, ScoreDisplay.FormateRolls(rolls.ToList()));
    }
    [Test]
    public void T03_bowl19()
    {
        int[] rolls = { 1, 9 };
        string rollsString = "1/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormateRolls(rolls.ToList()));
    }
    [Test]
    public void T04_bowl191()
    {
        int[] rolls = { 1, 9, 1 };
        string rollsString = "1/1";
        Assert.AreEqual(rollsString, ScoreDisplay.FormateRolls(rolls.ToList()));
    }
    [Test]
    public void T05_spareframe10()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 3 };
        string rollsString = "1111111111111111111/3";
        Assert.AreEqual(rollsString, ScoreDisplay.FormateRolls(rolls.ToList()));
    }
    [Test]
    public void T06_stikelastframe()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1 };
        string rollsString = "111111111111111111X11";
        Assert.AreEqual(rollsString, ScoreDisplay.FormateRolls(rolls.ToList()));
    }
    [Test]
    public void T07_rollszero()
    {
        int[] rolls = { 0 };
        string rollsString = "-";
        Assert.AreEqual(rollsString, ScoreDisplay.FormateRolls(rolls.ToList()));
    }
}
