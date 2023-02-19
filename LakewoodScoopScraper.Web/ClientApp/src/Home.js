import React, { useEffect, useState } from 'react';
import axios from 'axios';

const Home = () => {
    const [posts, setPosts] = useState([]);
    
    useEffect(() => {
        const scrapeLakewoodScoop = async() => {
            const { data } = await axios.get('/api/lakewoodscoop/scrape');
            setPosts(data);
        }
        
        scrapeLakewoodScoop();

    }, [])

    return <div className='container mt-5'>
        <table className='table table-hover table-striped table-bordered'>    
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Image</th>
                    <th>Blurb of Text</th>
                    <th>Amount of Comments</th>
                </tr>
            </thead>
            <tbody>
                {posts.map((post, i) => {
                return <tr key={i}>
                        <td>
                            <a href={post.link}>{post.title}</a>
                        </td>
                        <td><img src={post.imageUrl}/></td>
                        <td>{post.blurb}</td>
                        <td>{post.commentsCount}</td>
                    </tr>
                })}
            </tbody>
        </table>
    </div>
}

export default Home; 