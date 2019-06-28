import React, { Component } from 'react';
import axios from 'axios';

export class GameList extends Component {
    static displayName = GameList.name;

    constructor(props) {
        super(props);
        this.state = { games: [], loading: true };
    }

    componentDidMount() {
        this.getGames();
    }

    static renderGamesTable(games) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Published</th>
                        <th>Created</th>
                        <th>Created by</th>
                    </tr>
                </thead>
                <tbody>
                    {games.map(item =>
                        <tr key={item.ID}>
                            <td>{item.ID}</td>
                            <td>{item.Name}</td>
                            <td>{item.Published.toString()}</td>
                            <td>{item.Created}</td>
                            <td>{item.CreatedBy.UserName}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : GameList.renderGamesTable(this.state.games);

        return (
            <div>
                <h1>Game list</h1>
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
        const response = await axios.get('http://localhost:50992/api/games/getgames');
        const { data } = response;
        this.setState({ games: data, loading: false });
    }
}
