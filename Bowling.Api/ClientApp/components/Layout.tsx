import * as React from 'react';
import { Bowling } from './Bowling';

export class Layout extends React.Component<{}, {}> {
    public render() {
        return <div className='container-fluid'>
            <div className='row'>
                <div className='col-sm-3'>
                    
                </div>
                <div className='col-sm-9'>
                    <Bowling />
                </div>
            </div>
        </div>;
    }
}
