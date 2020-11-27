import axios from 'axios';
import React, { Component } from 'react';

export default class LoginService extends Component {
    state = {};
    componentDidMount() {
       
        axios.get('user').then(
            res => {
                this.setState({
                    user: res.data
                });
            },
            err => {
                console.log(err);
            }
        )
    }

    render() {
        if(this.state.user) {
            return (
                <h2>Welcome You are logged in</h2>
            )
        }
        return (
            <h2>you are log in</h2>
        )
    }
}