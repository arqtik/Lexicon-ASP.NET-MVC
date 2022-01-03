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
            return <div>Error: {this.state.error.message}</div>
        }
        else if (!isLoaded){
            return <div>Loading Person...</div>
        } else {
            return (
                <div>
                    <table className="table">
                        <thead>
                            <tr>
                                <th scope="col">{person.id}</th>
                                <th scope="col">{person.firstName}</th>
                                <th scope="col">{person.lastName}</th>
                                <th scope="col">{person.gender}</th>
                                <th scope="col">{person.city}</th>
                                <th scope="col">{person.email}</th>
                                <th scope="col">{person.languages}</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            );
        }
    }
}

export default PersonDetails;