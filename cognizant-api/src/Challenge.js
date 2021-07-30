import React, { Component } from 'react'
import { Form, Button } from 'react-bootstrap'
import { Base_URL, CLIENT_ID, CLIENT_SECRET } from "./jdoodle"
export default class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            challenges: [],
            value: 1,
            solution: "using System; \nclass Program {\nstatic void Main(string[] args) {\n//Your code goes here\n}\n}",            
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    refreshList() {
        fetch('http://localhost:20005/api/challenges')
            .then(response => response.json())
            .then(data => {
                this.setState({ challenges: data });
            })
    }
    componentDidMount() {
        this.refreshList();
    }
    handleChange(event) {
        this.setState({
            [event.target.name]: event.target.value
        });
    }
    handleSubmit(event) {
        this.sendCodeToServer();
        
        event.preventDefault();
    }
    sendCodeToServer = async(e) => {
        const options = {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                clientId: CLIENT_ID,
                clientSecret: CLIENT_SECRET,
                script: this.state.solution,
                language: "csharp",
                versionIndex: "3",
            })
        };
        try {
            const res = await fetch(Base_URL, options);
            const response = await res.json();
            this.setState({
                ...this.state,
                result: response,
            });
        } catch (err) {
            this.setState({
                ...this.state,
                err: {
                    title: "Failed",                                    
                },
            });
        }                
        fetch('http://localhost:20005/api/players', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                playerName: this.state.name,
                solution: this.state.solution,
                result: this.state.result.output
            })
        }).then(res => res.json()).then((result) => {
            alert('Added Successfully');
            this.refreshList();
        }, (err) => {
            alert('Failed');
        })
        this.refreshList();
    };
    render() {
        const { challenges } = this.state;
        const optionId = challenges.map((challenge) =>
                <option key = { challenge.challengeId } > { challenge.challengeId } </option>)            
        const optionDescription = challenges.map((challenge) => challenge.description);
        let list = optionDescription[this.state.value - 1];
        return ( 
            <div>
                <Form onSubmit = { this.handleSubmit } method="POST" autoComplete="off">
                    <Form.Group className = "mb-3">
                        <Form.Label> Player Name: </Form.Label> 
                        <Form.Control
                        type = 'text'
                        name = "name"
                        value = { this.state.name }
                        onChange = { this.handleChange }
                        required / >
                    </Form.Group> 

                    <label className = "challenge" > Select Challenge:
                        <select name = "value"
                        value = { this.state.value }
                        onChange = { this.handleChange } > { optionId } 
                        </select>  
                        <p className="description"> Description: <br/>
                            {list} </p> 
                    </label>
                        
                    <Form.Group className = "mb-3" >
                        <Form.Label> Code Solution: </Form.Label> 
                        <Form.Control name = "solution"
                        as = "textarea"
                        rows = { 20 }
                        style = {
                            { fontSize: "15px" }
                        }
                        value = { this.state.solution }
                        onChange = { this.handleChange }
                        /> 
                    </Form.Group>

                    <Button variant = "primary"
                    type = "submit" >
                    Submit </Button> 
                </Form > 
            </div>
        )
    }
}