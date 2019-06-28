import React, { Component } from 'react';
import { Pie } from 'react-chartjs-2';

export class ReviewPie extends Component {
    static displayName = ReviewPie.name;

    constructor(props) {
        super(props);
        this.state = {
            reviews: {},
            loading: true
        };
    }

    componentDidMount() {
        this.getReviews();
    }

    static renderPieChart(reviews) {
        return (
            <Pie data={reviews} />
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ReviewPie.renderPieChart(this.state.reviews);

        return (
            <div>
                <h1>Reviews summary</h1>
                {contents}
            </div>
        );
    }

    async getReviews() {

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

        const data = {
            labels: [
                'Negative reviews',
                'Positive reviews'
            ],
            datasets: [{
                data: [300, 50],
                backgroundColor: [
                    '#FF6384',
                    '#36A2EB'
                ],
                hoverBackgroundColor: [
                    '#FF6384',
                    '#36A2EB'
                ]
            }]
        };
        this.setState({ reviews: data, loading: false });
    }
}
