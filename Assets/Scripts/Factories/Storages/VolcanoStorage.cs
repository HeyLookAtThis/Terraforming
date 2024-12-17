using System;
using UnityEngine.Events;

public class VolcanoStorage : ObjectsStorage, IDisposable
{
    private UnityAction _frozenVolcanoesChanged;
    private UnityAction _allVolcanoesFrozen;

    public VolcanoStorage(string storageName) : base(storageName)
    {
    }

    public event UnityAction FrozenVolcanoesValueChanged
    {
        add => _frozenVolcanoesChanged += value;
        remove => _frozenVolcanoesChanged -= value;
    }

    public event UnityAction AllVolcanoesFrozen
    {
        add => _allVolcanoesFrozen += value;
        remove => _allVolcanoesFrozen -= value;
    }

    public void Dispose()
    {
        UnsubscribeOnVolcanoes();
    }

    public Volcano GetVolcano(int index) => (Volcano)InteractiveObjects[index];

    public int GetFrozenCount()
    {
        int frozenCount = 0;

        for (int i = 0; i < this.Count; i++)
            if (GetVolcano(i).IsFrozen)
                frozenCount++;

        return frozenCount;
    }

    public void SubscribeOnVolcano(Volcano volcano) => volcano.WasFrozen += OnFrozen;

    public void UnsubscribeOnVolcanoes()
    {
        for (int i = 0; i < this.Count; i++)
            GetVolcano(i).WasFrozen -= OnFrozen;
    }

    private void OnFrozen()
    {
        _frozenVolcanoesChanged?.Invoke();

        if(this.Count == GetFrozenCount())
            _allVolcanoesFrozen?.Invoke();
    }
}
