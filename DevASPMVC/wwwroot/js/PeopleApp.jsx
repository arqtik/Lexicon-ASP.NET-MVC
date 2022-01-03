import PeopleTable from "./PeopleIndex.jsx";
import PersonDetails from "./PersonDetails";

const routes = {
    index: 0,
    details: 1
}

class PeopleApp extends React.Component {
    state = {
        route: routes.index,
        personId: null
    }
    
    personDetails(id) {
        this.setState({route: routes.details, personId: id});
    }
    
    render() {
        switch (this.state.route) {
            case routes.index:
                return (
                    <div>
                        <h1>Index Page</h1>
                        <PeopleTable onPersonDetails={this.personDetails}/>
                    </div>
                )
            case routes.details:
                return (
                    <div>
                        <h1>Details on person</h1>
                        <PersonDetails personId={this.state.personId}/>
                    </div>
                )
        }
    }
}

ReactDOM.render(<PeopleApp/>, document.getElementById('content'));