<script>
	import { onMount } from 'svelte';

	// export let news_count = 10;

	let listOfNews = [];

	let counter = 1;

	// reactive statement: viene eseguito quando cambia la proprietà interna al blocco.
	$: {
		console.log(counter);
		if (counter > 5) {
			alert('stop it!');
		}
	}

	onMount(async () => {
		listOfNews = await GetListOfNewsAsync();
	});

	async function OnRefreshButtonClicked() {
		listOfNews = await GetListOfNewsAsync();
		counter++;
	}

	async function GetListOfNewsAsync() {
		const response = await fetch('http://localhost:5002/api/News');
		const data = await response.json();
		console.log(data);
		return data;
	}
</script>

<h4>List of last news</h4>
<ul>
	{#each listOfNews as { title, timestamp }}
		<li>
			{title} [{timestamp}]
			{#if new Date(timestamp).getFullYear() < new Date().getFullYear()}
				<strong style="color: gray;">TOO OLD!</strong>
			{/if}
		</li>
	{:else}
		<p>no news!</p>
	{/each}
</ul>

<button class="btn btn-primary" on:click={OnRefreshButtonClicked}>Refresh</button>
<!-- <input bind:value={counter} /> -->
