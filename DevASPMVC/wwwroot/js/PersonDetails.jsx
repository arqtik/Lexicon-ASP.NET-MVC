import Error from "./ReactUtilities/Error.jsx";

class DeletePersonButton extends React.Component {
    render() {
        return (
            <button className={"btn btn-danger"} onClick={() => this.props.onPersonDelete(this.props.personId)}>Delete Person</button>
        );
    }
}

class PersonDetailsTable extends React.Component {
    formatLanguages = (languages) => {
        let languagesString = "";
        languages.map(obj => languagesString += obj.language.name + " ");
        return languagesString.trim();
    }
    
    render() {
        const person = this.props.person;
        
        return (
            <table className="table">
                <thead>
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">First Name</th>
                    <th scope="col">Last Name</th>
                    <th scope="col">Gender</th>
                    <th scope="col">City</th>
                    <th scope="col">E-mail</th>
                    <th scope="col">Languages</th>
                </tr>
                </thead>
                <tbody>
                    <tr>
                        <td scope="col">{person.id}</td>
                        <td scope="col">{person.firstName}</td>
                        <td scope="col">{person.lastName}</td>
                        <td scope="col">{person.gender}</td>
                        <td scope="col">{person.city.name}</td>
                        <td scope="col">{person.email}</td>
                        <td scope="col">{this.formatLanguages(person.languages)}</td>
                    </tr>
                </tbody>
            </table>
        );
    }
}

class PersonDetails extends React.Component {
    state = {
        isLoaded: false,
        error: null,
        person: null
    }
    
    componentDidMount(){
        // fetch full person details
        fetch("https://localhost:5001/React/Person/" + this.props.personId)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        person: result
                    })
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    })
                }
            );
    }
    
    render() {
        const { error, isLoaded, person} = this.state;
        if (error) {
            <Error message={error.message}/>
        } 
        else if (!isLoaded){
            return <div>Loading Person...</div>
        } else {
            return (
                <div>
                    <PersonDetailsTable person={person}/>
                    <DeletePersonButton onPersonDelete={this.props.onPersonDelete} personId={person.id}/>
                </div>
            );
        }
    }
}

export default PersonDetails;