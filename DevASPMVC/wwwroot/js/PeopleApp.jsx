import PeopleTable from "./PeopleIndex.jsx";
import PersonDetails from "./PersonDetails.jsx";

const routes = {
    index: 0,
    details: 1
}

class BackButton extends React.Component {
    render() {
        return (
            <div>
                <button onClick={() => this.props.onBack()}>&#11178;</button>
            </div>
        );
    }
}

class PeopleApp extends React.Component {
    state = {
        route: routes.index,
        personId: null,
        status: null
    }
    
    back = () => {
        this.setState({
            route: routes.index
        })
    }
    
    personDetails = (id) => {
        this.setState({
            route: routes.details,
            personId: id
        });
    }

    personDelete = (id) => {
        fetch("https://localhost:5001/React/DeletePerson/" + id, { method: 'DELETE' })
            .then(() => this.setState({ status: 'Delete successful' }));
    }
    
    render() {
        let status = null;
        
        if (this.state.status){
            status = <div className="p-3 mb-2 bg-success text-white">Status: {status}</div>
        }
        
        switch (this.state.route) {
            case routes.index:
                return (
                    <div>
                        {status}
                        <h1>Index Page</h1>
                        <PeopleTable onPersonDetails={this.personDetails}/>
                    </div>
                )
            case routes.details:
                return (
                    <div>
                        <BackButton onBack={this.back}/>
                        <h1>Details on person</h1>
                        <PersonDetails onPersonDelete={this.personDelete} personId={this.state.personId}/>
                    </div>
                )
        }
    }
}

ReactDOM.render(<PeopleApp/>, document.getElementById('content'));