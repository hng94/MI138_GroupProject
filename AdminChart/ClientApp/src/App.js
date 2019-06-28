import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Counter } from './components/Counter';
import { GameList } from './components/GameList';
import { GameChart } from './components/GameChart';
import { ReviewPie } from './components/ReviewPie';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={GameList} />
            <Route path='/review-pie' component={ReviewPie} />
            <Route path='/game-chart' component={GameChart} />
      </Layout>
    );
  }
}
