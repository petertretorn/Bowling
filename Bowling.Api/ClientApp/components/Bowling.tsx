import * as React from 'react';
import 'isomorphic-fetch';

interface BowlingState {
    result: boolean,
    scores: [Number[]],
    calculatedPoints: Number[],
    isPristine: boolean
}

export class Bowling extends React.Component<{}, BowlingState> {
    constructor() {
        super();
        this.handleClick = this.handleClick.bind(this);
        this.state = {
            result: false,
            scores: [[]],
            calculatedPoints: [],
            isPristine: true
        }
    }

    handleClick() {
        fetch('api/bowling')
            .then(response => response.json() as Promise<BowlingState>)
            .then(data => {
                this.setState({
                    result: true,
                    scores: data.scores,
                    calculatedPoints: data.calculatedPoints,
                    isPristine: false
                });
            });
    }
    

    public render() {

        const isPristine = this.state.isPristine;

        const content = (isPristine)
            ? (<div>Press button to see results</div>)
            : (<div>
                 <div>Result: {(this.state.result) ? 'Correct!' : 'Wrong'}</div>
                 <div>Scores: {this.state.scores}</div>
                <div>calculatedPoints: {this.state.calculatedPoints}</div>
               </div>);

        return (
            <div>
                <h1>Bowling Validation</h1>
                <p>Click for validating random bowling result</p>
                <button onClick={this.handleClick}>Validate</button>
                {content}
            </div>
        );
    }
    
}
