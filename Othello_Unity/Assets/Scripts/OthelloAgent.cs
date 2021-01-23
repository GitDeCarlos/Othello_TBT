using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEngine.Serialization;

public enum HeuristicMethod
{
    Random,
    MinMax
}

public class OthelloAgent : Agent
{
    public Player type;
    public HeuristicMethod heuristicMethod;
    private GameController manager;

    public override void OnEpisodeBegin()
    {
        type = GetComponent<BehaviorParameters>().TeamId == 0 ? Player.B : Player.W;
    }

    public override void Heuristic(float[] actionsOut)
    {
        var availableOptions = (int[])manager.GetAvailableFields();

        if (heuristicMethod == HeuristicMethod.Random)
        {
            int randomField = availableOptions[Random.Range(0, availableOptions.Length)];
            actionsOut[0] = randomField;
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        foreach (var field in board.Fields)
        {
            sensor.AddOneHotObservation(field.ObserveField(type), 3);
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        board.SelectField(Mathf.FloorToInt(vectorAction[0]), type);
    }

    public override void CollectDiscreteActionMasks(DiscreteActionMasker actionMasker)
    {
        actionMasker.SetMask(0, board.GetOccupiedFields());
    }
}
