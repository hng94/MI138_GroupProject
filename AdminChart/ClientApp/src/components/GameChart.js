import React, { Component } from 'react';
import { Bar } from 'react-chartjs-2';


export class GameChart extends Component {
    static displayName = GameChart.name;

    constructor(props) {
        super(props);
        this.state = {
            games: {},
            loading: true
        };
    }

    componentDidMount() {
        this.getGames();
    }

    static renderGamesTable(games) {
        return (
            <Bar data={games} />
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : GameChart.renderGamesTable(this.state.games);

        return (
            <div>
                <h1>Game reviews summary</h1>
                {contents}
            </div>
        );
    }

    async getGames() {

        //const response = await fetch('http://localhost:50992/api/games/getgames', {
        //    method: "GET",
        //    mode: "cors",
        //    headers: {
        //        'Content-Type': 'application/json'
        //    }
        //});
        //const data = await response.json();
        //const response = await axios.get('http://localhost:50992/api/games/getgames');
        //const { data } = response;
        
        let data = {
            labels: ["Dota 2", "Underlords", "CS", "LoL", "Warcry", "DmC", "PUBG"],
            datasets: [
                {
                    label: "Positive reviews",
                    backgroundColor: '#36A2EB',
                    borderColor: '#36A2EB',
                    borderWidth: 1,
                    hoverBackgroundColor: '#36A2EB',
                    hoverBorderColor: '#36A2EB',
                    data: [65, 59, 80, 81, 56, 55, 40]
                },
                {
                    label: "Negative reviews",
                    backgroundColor: 'rgba(255,99,132,0.2)',
                    borderColor: 'rgba(255,99,132,1)',
                    borderWidth: 1,
                    hoverBackgroundColor: 'rgba(255,99,132,0.4)',
                    hoverBorderColor: 'rgba(255,99,132,1)',
                    data: [28, 48, 40, 19, 86, 27, 90]
                }
            ]
        };
        this.setState({ games: data, loading: false });
    }
}
