using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraEnterpriseSDLC
{
    enum RiskLevel
    {
        Low,
        Medium,
        High,
        Critical
    }

    enum SDLCStage
    {
        Backlog,
        Requirement,
        Design,
        Development,
        CodeReview,
        Testing,
        UAT,
        Deployment,
        Maintenance
    }

    sealed class Requirement
    {
        public int Id { get; }
        public string Title { get; }
        public RiskLevel Risk { get; }

        public Requirement(int id, string title, RiskLevel risk)
        {
            Id = id;
            Title = title;
            Risk = risk;
        }
    }

    sealed class WorkItem
    {
        public int Id { get; }
        public string Name { get; }
        public SDLCStage Stage { get; set; }
        public HashSet<int> DependencyIds { get; }

        public WorkItem(int id, string name, SDLCStage stage)
        {
            Id = id;
            Name = name;
            Stage = stage;
            DependencyIds = new HashSet<int>();
        }
    }

    sealed class BuildSnapshot
    {
        public string Version { get; }
        public DateTime Timestamp { get; }

        public BuildSnapshot(string version)
        {
            Version = version;
            Timestamp = DateTime.Now;
        }
    }

    sealed class AuditLog
    {
        public DateTime Time { get; }
        public string Action { get; }

        public AuditLog(string action)
        {
            Time = DateTime.Now;
            Action = action;
        }
    }

    sealed class QualityMetric
    {
        public string Name { get; }
        public double Score { get; }

        public QualityMetric(string name, double score)
        {
            Name = name;
            Score = score;
        }
    }

    class EnterpriseSDLCEngine
    {
        private List<Requirement> _requirements;
        private Dictionary<int, WorkItem> _workItemRegistry;
        private SortedDictionary<SDLCStage, List<WorkItem>> _stageBoard;
        private Queue<WorkItem> _executionQueue;
        private Stack<BuildSnapshot> _rollbackStack;
        private HashSet<string> _uniqueTestSuites;
        private LinkedList<AuditLog> _auditLedger;
        private SortedList<double, QualityMetric> _releaseScoreboard;
        private int _requirementCounter;
        private int _workItemCounter;

        public EnterpriseSDLCEngine()
        {
            _requirements = new List<Requirement>();
            _workItemRegistry = new Dictionary<int, WorkItem>();
            _stageBoard = new SortedDictionary<SDLCStage, List<WorkItem>>();
            foreach (SDLCStage stage in Enum.GetValues(typeof(SDLCStage)))
                _stageBoard[stage] = new List<WorkItem>();

            _executionQueue = new Queue<WorkItem>();
            _rollbackStack = new Stack<BuildSnapshot>();
            _uniqueTestSuites = new HashSet<string>();
            _auditLedger = new LinkedList<AuditLog>();
            _releaseScoreboard = new SortedList<double, QualityMetric>();
        }

        public void AddRequirement(string title, RiskLevel risk)
        {
            var req = new Requirement(_requirementCounter++, title, risk);
            _requirements.Add(req);
            _auditLedger.AddLast(new AuditLog($"Requirement added: {title}, Risk: {risk}"));
        }

        public WorkItem CreateWorkItem(string name, SDLCStage stage)
        {
            var wi = new WorkItem(_workItemCounter++, name, stage);
            _workItemRegistry[wi.Id] = wi;
            _stageBoard[stage].Add(wi);
            _auditLedger.AddLast(new AuditLog($"WorkItem created: {name} at stage {stage}"));
            return wi;
        }

        public void AddDependency(int workItemId, int dependsOnId)
        {
            if (!_workItemRegistry.ContainsKey(workItemId) ||
                !_workItemRegistry.ContainsKey(dependsOnId))
                return;

            _workItemRegistry[workItemId].DependencyIds.Add(dependsOnId);
            _auditLedger.AddLast(
                new AuditLog($"Dependency added: WorkItem {workItemId} depends on {dependsOnId}")
            );
        }

        public void PlanStage(SDLCStage stage)
        {
            var eligible = _stageBoard[stage]
                .Where(wi =>
                    wi.DependencyIds.All(depId =>
                        _workItemRegistry[depId].Stage > stage))
                .ToList();

            foreach (var wi in eligible)
                _executionQueue.Enqueue(wi);

            _auditLedger.AddLast(new AuditLog($"Stage planned: {stage}"));
        }

        public void ExecuteNext()
        {
            if (_executionQueue.Count == 0)
                return;

            var wi = _executionQueue.Dequeue();
            var previousStage = wi.Stage;
            wi.Stage++;

            _stageBoard[previousStage].Remove(wi);
            _stageBoard[wi.Stage].Add(wi);

            _auditLedger.AddLast(
                new AuditLog($"Executed WorkItem {wi.Id}: {previousStage} -> {wi.Stage}")
            );
        }

        public void RegisterTestSuite(string suiteId)
        {
            _uniqueTestSuites.Add(suiteId);
            _auditLedger.AddLast(new AuditLog($"Test suite registered: {suiteId}"));
        }

        public void DeployRelease(string version)
        {
            var snapshot = new BuildSnapshot(version);
            _rollbackStack.Push(snapshot);
            _auditLedger.AddLast(new AuditLog($"Release deployed: {version}"));
        }

        public void RollbackRelease()
        {
            if (_rollbackStack.Count == 0)
                return;

            var snapshot = _rollbackStack.Pop();
            _auditLedger.AddLast(new AuditLog($"Rollback executed for version: {snapshot.Version}"));
        }

        public void RecordQualityMetric(string metricName, double score)
        {
            if (_releaseScoreboard.ContainsKey(score))
                return;

            _releaseScoreboard.Add(score, new QualityMetric(metricName, score));
        }

        public void PrintAuditLedger()
        {
            foreach (var log in _auditLedger)
                Console.WriteLine($"{log.Time}: {log.Action}");
        }

        public void PrintReleaseScoreboard()
        {
            foreach (var entry in _releaseScoreboard.Reverse())
                Console.WriteLine($"{entry.Value.Name}: {entry.Key:F2}");
        }
    }

    class Main4
    {
        public static void main4()
        {
            var engine = new EnterpriseSDLCEngine();

            engine.AddRequirement("Single Sign-On", RiskLevel.High);
            engine.AddRequirement("Fraud Detection", RiskLevel.Critical);

            var design = engine.CreateWorkItem("SSO Design", SDLCStage.Design);
            var dev = engine.CreateWorkItem("SSO Development", SDLCStage.Development);
            var test = engine.CreateWorkItem("SSO Testing", SDLCStage.Testing);

            engine.AddDependency(dev.Id, design.Id);
            engine.AddDependency(test.Id, dev.Id);

            engine.RegisterTestSuite("SSO-Regression");
            engine.RegisterTestSuite("SSO-Security-Smoke");

            engine.PlanStage(SDLCStage.Design);
            engine.ExecuteNext();
            engine.ExecuteNext();

            engine.DeployRelease("v3.4.1");

            engine.RecordQualityMetric("Code Coverage", 91.7);
            engine.RecordQualityMetric("Security Score", 97.3);

            engine.RollbackRelease();

            engine.PrintAuditLedger();
            engine.PrintReleaseScoreboard();
        }
    }
}
