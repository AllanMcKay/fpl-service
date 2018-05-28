using System;
using Data.Interfaces;
using System.Collections.Generic;

namespace Data.Models
{
    public class FPLPlayer : IStorable
    {
        public int id {get;set;}
        public string photo {get;set;}
        public string web_name {get;set;}
        public string team_code {get;set;}
        public string status {get;set;}
        public string code {get;set;}
        public string first_name {get;set;}
        public string second_name {get;set;}
        public string news {get;set;}
        public int now_cost {get;set;}
        public DateTime? news_added {get;set;}
        public int? chance_of_playing_this_round {get;set;} 
        public int? chance_of_playing_next_round {get;set;}
        public decimal value_form {get;set;}
        public decimal value_season {get;set;}
        public int cost_change_start {get;set;}
        public int cost_change_event {get;set;}
        public int cost_change_start_fall {get;set;}
        public int cost_change_event_fall {get;set;}
        public bool in_dreamteam {get;set;}
        public int dreamteam_count {get;set;}
        public decimal selected_by_percent {get;set;}
        public decimal form {get;set;}
        public int transfers_out {get;set;}
        public int transfers_in {get;set;}
        public int transfers_out_event {get;set;}
        public int transfers_in_event {get;set;}
        public int total_points {get;set;}
        public int event_points {get;set;}
        public decimal points_per_game {get;set;}
        public decimal? ep_this {get;set;}
        public decimal? ep_next {get;set;}
        public bool special {get;set;}
        public int minutes {get;set;}
        public int goals_scored {get;set;}
        public int assists {get;set;}
        public int clean_sheets {get;set;}
        public int goals_conceded {get;set;}
        public int own_goals {get;set;}
        public int penalties_saved {get;set;}
        public int penalties_missed {get;set;}
        public int yellow_cards {get;set;}
        public int red_cards {get;set;}
        public int saves {get;set;}
        public int bonus {get;set;}
        public int bps {get;set;}
        public decimal influence {get;set;}
        public decimal creativity {get;set;}
        public decimal threat {get;set;}
        public decimal ict_index {get;set;}
        public int ea_index {get;set;}
        public int element_type {get;set;} 
        public int team{get;set;}

        public List<string> Tags 
        {
            get
            {
                return new List<string>() {first_name,second_name};
            }
        }

        public string Kind {get{return "fpl_player";}}
    }
}