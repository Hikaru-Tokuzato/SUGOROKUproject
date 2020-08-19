﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    
    private Stage _stage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void StartGame()
    {
        //ステージ選択
        _stage = new Stage();

        // grids の情報を取得
        // GameObject.FindWithTags
        var grids = new Grid[] {new Grid(), new Grid(),};
        _stage.MakeStage(grids);

        //人数聞く
        var playerNum = 1;
        _stage.MakePlayer(playerNum);

        _stage.MakeOrder();

        while (!_stage.IfFinishGame())
        {
            for (int i = 0; i < _stage.GetActivePlayersNum(); i++)
            {
                //行動の提示
                var actionNumber = 1;
                _stage.ForceAction(actionNumber, i);
            }

            _stage.turn = _stage.turn + 1;
        }
    }
}
